using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Model
{
    [Table("pessoas_juridicas")]
    public class PessoaJuridica
    {
        [Key]
        [Column("id_pessoa")]
        public int IdPessoa { get; set; }

        [Column("razao_social")]
        public string RazaoSocial { get; set; }

        [Column("nome_fantasia")]
        public string NomeFantasia { get; set; }

        [Column("cnpj")]
        public string CNPJ{ get; set; }

        [Column("inscricao_municipal")]
        public string InscricaoMunicipal { get; set; }

        [Column("inscricao_estadual")]
        public string InscricaoEstadual { get; set; }

        [ForeignKey("IdPessoa")]
        public virtual Pessoa FK_Pessoa { get; set; }
    }
}
