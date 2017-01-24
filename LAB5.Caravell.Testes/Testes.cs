using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LAB5.Caravell.Data.Model;
using LAB5.Caravell.Data.Repositories;

namespace LAB5.Caravell.Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSalvarPessoaFisica()
        {


            PessoaFisica pf = new PessoaFisica();
            pf.FK_Pessoa = new Pessoa();
            pf.FK_Pessoa.FK_Endereco = new Endereco();

            pf.FK_Pessoa.FK_Endereco.Bairro = "Bancários";
            pf.FK_Pessoa.FK_Endereco.Cidade = "João Pessoa";
            pf.FK_Pessoa.FK_Endereco.Estado = "PB";
            pf.FK_Pessoa.FK_Endereco.Logradouro = "José Alexandre de Farias, 634";

            pf.FK_Pessoa.DDD1 = "83";
            pf.FK_Pessoa.DDD2 = "83";
            pf.FK_Pessoa.Telefone1 = "988588449";
            pf.FK_Pessoa.Telefone2 = "32351812";
            pf.CPF = "07216791452";
            pf.Rg = "3063806";
            pf.DataNascimento = DateTime.Parse("17/01/1987");
            pf.Email = "daniellxc@gmail.com";
            pf.Nome = "Daniel Xavier Cardoso";

            new PessoaFisicaRepository().Save(pf);
            Assert.AreNotEqual(pf.IdPessoa, 0);


        }
    }
}
