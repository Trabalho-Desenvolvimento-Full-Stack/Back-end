using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Back_end.Context
{
    public class EcommerceContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Enderecos { get; set; }
        public DbSet<ItemPedido> UsuariosMaster { get; set; }
        public DbSet<Pedido> Vendas { get; set; }
        public DbSet<Produto> Voos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=45.93.100.120,1433;initial catalog=aereo;persist security info=True;user id=suporte;password=suporte;MultipleActiveResultSets=True;App=exeEf;");
            
        }
    }
}