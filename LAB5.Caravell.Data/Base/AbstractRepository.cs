using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Base
{
    public abstract class AbstractRepository<T> where T : class
    {

        private IContext _context;

        private DbContext contextoConcreto;



        public AbstractRepository(IContext context)
        {
            _context = context;

            contextoConcreto = _context.GetContext();

        }


        public void Add(T entity)
        {

            contextoConcreto.Set<T>().Add(entity);

        }



        public void BulkInsert(IEnumerable<T> entities)
        {

            contextoConcreto.Set<T>().AddRange(entities);
            contextoConcreto.SaveChanges();


        }





        public void Delete(T entity)
        {
            contextoConcreto.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            CommitChanges();
        }

        public List<T> Find(Expression<Func<T, bool>> where)
        {

            return contextoConcreto.Set<T>().Where<T>(where).ToList();
        }


        public T Get(params Object[] keys)
        {
            return contextoConcreto.Set<T>().Find(keys);
        }

        public List<T> GetAll()
        {

            return contextoConcreto.Set<T>().ToList<T>();

        }


        public void Update(T updateEntity, object key)
        {
            var original = this.Get(key);
            if (original != null)
            {
                contextoConcreto.Entry(original).CurrentValues.SetValues(updateEntity);
                contextoConcreto.SaveChanges();
            }

        }

        public virtual void Update(T entity)
        {
            contextoConcreto.Entry(entity).State = EntityState.Modified;
            contextoConcreto.SaveChanges();
        }

        public void Update(List<T> entities)
        {
            foreach (var entity in entities)
            {
                contextoConcreto.Entry(entity).State = EntityState.Modified;
            }

            contextoConcreto.SaveChanges();

        }



        public int ExecuteCommand(string sqlQuery, Array parms)
        {
            return contextoConcreto.Database.ExecuteSqlCommand(sqlQuery, parms);
        }

        public DbContext GetContext()
        {
            return contextoConcreto;
        }

        public void CommitChanges()
        {
            contextoConcreto.SaveChanges();
        }

        public void InsertData(List<T> list)
        {

            DataTable dt = new DataTable("MyTable");
            dt = ConvertToDataTable(list);
            //ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(contextoConcreto.Database.Connection.ConnectionString))
            {
                bulkcopy.BulkCopyTimeout = 660;
                bulkcopy.DestinationTableName = contextoConcreto.GetTableName<T>();
                bulkcopy.WriteToServer(dt);
            }
            dt = null;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {

            List<PropertyDescriptor> properties = RemoveNotMapped(TypeDescriptor.GetProperties(typeof(T)));


            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }


        private static List<PropertyDescriptor> RemoveNotMapped(PropertyDescriptorCollection properties)
        {
            bool adiciona = true;
            List<PropertyDescriptor> propriedades = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor prop in properties)
            {
                foreach (Attribute atr in prop.Attributes)
                {
                    if (atr.ToString().Contains("NotMapped"))
                        adiciona = false;
                }
                if (adiciona)
                    propriedades.Add(prop);

                adiciona = true;
            }



            return propriedades;
        }



    }
}

