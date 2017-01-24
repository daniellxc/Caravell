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
    public class MercadoriaRepository
    {
        private class DAO : AbstractRepository<Mercadoria>
        {
            public DAO(Context ctx) : base(ctx)
            {

            }
        }

        private DAO _dao = new DAO(new Context());

        public void Save(Mercadoria mercadoria)
        {
            try
            {
                if (mercadoria.Id == 0)
                {
                    _dao.Add(mercadoria);
                    _dao.CommitChanges();
                }
                else
                {
                    _dao.Update(mercadoria, mercadoria.Id);
                }

            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception("Erro ao salvar mercadoria. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar mercadoria. " + ex.Message);
            }
        }

        public void Delete(Mercadoria mercadoria)
        {
            try
            {
                _dao.Delete(mercadoria);

            }
            catch (DbUpdateException dbex)
            {
                throw new Exception("Erro ao excluir mercadoria. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir mercadoria. " + ex.Message);
            }
        }

        public Mercadoria Get(int id)
        {
            return _dao.Get(id);
        }
    }
}
