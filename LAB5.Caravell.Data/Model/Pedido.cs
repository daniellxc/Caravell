using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Model
{
    [Table("pedidos")]
    public class Pedido
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_pessoa")]
        public int IdPessoa { get; set; }

        [Column("data_pedido")]
        public DateTime DataPedido { get; set; }

        [Column("informacoes_adicionais")]
        public string InformacoesAdicionais { get; set; }

        [ForeignKey("IdPessoa")]
        public virtual Pessoa FK_Pessoa { get; set; }

    }
}
