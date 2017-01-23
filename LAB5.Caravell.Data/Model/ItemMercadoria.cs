using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Model
{
    [Table("itens_mercadoria")]
    public class ItemMercadoria
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_mercadoria")]
        public int IdMercadoria { get; set; }

        [Column("id_medida")]
        public int IdMedida { get; set; }

        [Column("valor_compra")]
        public decimal ValorCompra { get; set; }

        [Column("margem_lucro")]
        public decimal MargemLucro { get; set; }

        [Column("data_entrada")]
        public DateTime DataEntrada{ get; set; }

        [Column("quantidade")]
        public decimal Quantidade { get; set; }


        [ForeignKey("IdMedida")]
        public virtual Medida FK_Medida { get; set; }

        [ForeignKey("IdMercadoria")]
        public virtual Mercadoria FK_Mercadoria { get; set; }


    }
}
