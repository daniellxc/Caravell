using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Model
{
    [Table("medidas")]
    public class Medida
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public  string Nome { get; set; }

        [Column("sigla")]
        public string Sigla { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}
