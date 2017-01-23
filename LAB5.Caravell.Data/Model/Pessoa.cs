using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Model
{
    [Table("pessoas")]
    public class Pessoa
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_endereco")]
        public int IdEndereco { get; set; }

        [Column("ddd1")]
        public string DDD1 { get; set; }

        [Column("telefone1")]
        public string Telefone1 { get; set; }


        [Column("ddd2")]
        public string DDD2 { get; set; }

        [Column("telefone2")]
        public string Telefone2 { get; set; }

        [ForeignKey("IdEndereco")]
        public virtual Endereco FK_Endereco { get; set; }

    }
}
