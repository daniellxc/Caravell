using LAB5.Caravell.Data.Base;
using LAB5.Caravell.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Repositories
{
    public class PedidoRepository
    {
        private class DAO : AbstractRepository<Pedido>
        {
            public DAO(Context ctx) : base(ctx)
            {

            }
        }

        private DAO _dao = new DAO(new Context());

        public void Save(Pedido pedido)
        {
            try
            {
                if (pedido.Id == 0)
                {
                    _dao.Add(pedido);
                    _dao.CommitChanges();
                }
                else
                {
                    _dao.Update(pedido, pedido.Id);
                }

            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception("Erro ao salvar pedido. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar pedido. " + ex.Message);
            }
        }

        public void Delete(Pedido pedido)
        {
            try
            {
                _dao.Delete(pedido);

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
