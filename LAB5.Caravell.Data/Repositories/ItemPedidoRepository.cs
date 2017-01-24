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
    public class ItemPedidoRepository
    {
        private class DAO : AbstractRepository<ItemPedido>
        {
            public DAO(Context ctx) : base(ctx)
            {

            }
        }

        private DAO _dao = new DAO(new Context());

        public void Save(ItemPedido itemPedido)
        {
            try
            {
                if (itemPedido.Id == 0)
                {
                    _dao.Add(itemPedido);
                    _dao.CommitChanges();
                }
                else
                {
                    _dao.Update(itemPedido, itemPedido.Id);
                }

            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception("Erro ao item pedido. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar item pedido. " + ex.Message);
            }
        }

        public void Delete(ItemPedido itemPedido)
        {
            try
            {
                _dao.Delete(itemPedido);

            }
            catch (DbUpdateException dbex)
            {
                throw new Exception("Erro ao excluir endereço. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir endereço. " + ex.Message);
            }
        }

        public ItemPedido Get(int id)
        {
            return _dao.Get(id);
        }
    }
}
