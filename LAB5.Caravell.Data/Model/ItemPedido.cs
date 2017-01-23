using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Model
{
    [Table("itens_pedido")]
    public class ItemPedido
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_pedido")]
        public int IdPedido { get; set; }

        [Column("id_item_mercadoria")]
        public int IdItemMercadoria { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("valor_venda")]
        public decimal ValorVenda { get; set; }

        [Column("valor_final")]
        public decimal ValorFinal { get; set; }

    }
}
