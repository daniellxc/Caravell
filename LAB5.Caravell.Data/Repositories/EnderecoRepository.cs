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
    public class EnderecoRepository
    {
        private class DAO : AbstractRepository<Endereco>
        {
            public DAO(Context ctx) : base(ctx)
            {

            }
        }

        private DAO _dao = new DAO(new Context());

        public void Save(Endereco endereco)
        {
            try
            {
                if (endereco.Id == 0)
                {
                    _dao.Add(endereco);
                    _dao.CommitChanges();
                }
                else
                {
                    _dao.Update(endereco, endereco.Id);
                }

            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception("Erro ao salvar pessoa física. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar pessoa física. " + ex.Message);
            }
        }

        public void Delete(Endereco endereco)
        {
            try
            {
                _dao.Delete(endereco);

            }
            catch (DbUpdateException dbex)
            {
                throw new Exception("Erro ao salvar pessoa física. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir pessoa física. " + ex.Message);
            }
        }

        public PessoaFisica Get(int idPessoa)
        {
            return _dao.Get(idPessoa);
        }
    }
}
