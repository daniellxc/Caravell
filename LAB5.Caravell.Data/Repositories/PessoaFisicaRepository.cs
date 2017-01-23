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
    public class PessoaFisicaRepository
    {
        private class DAO : AbstractRepository<PessoaFisica>
        {
            public DAO(Context ctx):base(ctx)
            {

            }
        }

        private DAO _dao = new DAO(new Context());

        public void Save(PessoaFisica pessoaFisica)
        {
            try
            {
                if(pessoaFisica.IdPessoa == 0)
                {
                    _dao.Add(pessoaFisica);
                    _dao.CommitChanges();
                }else
                {
                    _dao.Update(pessoaFisica, pessoaFisica.IdPessoa);
                }

            }
            catch(DbEntityValidationException dbex)
            {
                throw new Exception("Erro ao salvar pessoa física. " + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar pessoa física. " + ex.Message);
            }
        }

        public void Delete(PessoaFisica pessoaFisica)
        {
            try
            {
                _dao.Delete(pessoaFisica);

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
