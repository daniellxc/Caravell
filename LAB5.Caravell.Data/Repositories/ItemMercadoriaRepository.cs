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
    public class ItemMercadoriaRepository
    {
        private class DAO : AbstractRepository<ItemMercadoria>
        {
            public DAO(Context ctx) : base(ctx)
            {

            }
        }

        private DAO _dao = new DAO(new Context());

        public void Save(ItemMercadoria itemMercadoria)
        {
            try
            {
                if (itemMercadoria.Id == 0)
                {
                    _dao.Add(itemMercadoria);
                    _dao.CommitChanges();
                }
                else
                {
                    _dao.Update(itemMercadoria, itemMercadoria.Id);
                }

            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception("Erro ao salvar item mercadoria. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar item mercadoria. " + ex.Message);
            }
        }

        public void Delete(ItemMercadoria itemMercadoria)
        {
            try
            {
                _dao.Delete(itemMercadoria);

            }
            catch (DbUpdateException dbex)
            {
                throw new Exception("Erro ao excluir item mercadoria. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir item mercardoria. " + ex.Message);
            }
        }

        public ItemMercadoria Get(int id)
        {
            return _dao.Get(id);
        }
    }
}
