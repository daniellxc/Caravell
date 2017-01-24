using LAB5.Caravell.Data.Base;
using LAB5.Caravell.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Repositories
{
    public class MedidaRepository
    {
        private class DAO : AbstractRepository<Medida>
        {
            public DAO(Context ctx) : base(ctx)
            {

            }
        }

        private DAO _dao = new DAO(new Context());

        public void Save(Medida medida)
        {
            try
            {
                if (medida.Id == 0)
                {
                    _dao.Add(medida);
                    _dao.CommitChanges();
                }
                else
                {
                    _dao.Update(medida, medida.Id);
                }

            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception("Erro ao salvar medida. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar medida. " + ex.Message);
            }
        }

        public void Delete(Medida medida)
        {
            try
            {
                _dao.Delete(medida);

            }
            catch (DbUpdateException dbex)
            {
                throw new Exception("Erro ao excluir medida. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir medida. " + ex.Message);
            }
        }

        public Medida Get(int id)
        {
            return _dao.Get(id);
        }
    }
}
