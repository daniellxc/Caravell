using LAB5.Caravell.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5.Caravell.Data.Base
{
    public class Context : DbContext, IContext
    {
        #region DbSets
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ItemMercadoria> ItensMercadoria { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Medida> Medidas { get; set; }
        public DbSet<Mercadoria> Mercadorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pessoa> Pessoas{ get; set; }
        public DbSet<PessoaJuridica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }

        #endregion

        public Context():base("CaravellConn")
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbContext GetContext()
        {
            return this;
        }
    }
}
