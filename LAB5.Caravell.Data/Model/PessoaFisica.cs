using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Model
{
    [Table("pessoas_fisicas")]
    public class PessoaFisica
    {
        [Key]
        [Column("id_pessoa")]
        public int IdPessoa { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("rg")]
        public string Rg { get; set; }

        [Column("cpf")]
        public string CPF { get; set; }

        [Column("data_nascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [ForeignKey("IdPessoa")]
        public virtual Pessoa FK_Pessoa { get; set; }


    }
}
