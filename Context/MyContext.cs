using Microsoft.EntityFrameworkCore;
using Suporte.Entity;
using Suporte.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Context {
    public class MyContext : DBContext
    {
        public DBSet<Cliente> Clientes {get; set;}
        public DBSet<Categoria> Categorias {get; set;}
        public DBSet<ItemPedido> ItensPedidos {get; set;}
        public DBSet<Pedido> Pedidos {get; set;}
        public DBSet<UserMaster> UsersMaster {get; set;}

        protected override void onConfiguring(DBcontextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("data source=45.93.100.120,1433;initial catalog=FS02;persist security info=True;user id=FS02;password=123456789;MultipleActiveResultSets=True;App=exeEf;");
        }

        protected override void onModelCreating(ModelBuilder builder) {
            base.onModelCreating(builder);
            builder.Entity<Cliente>(new clienteMapping().configure);
            builder.Entity<Categoria>(new categoriaMapping().configure);
            builder.Entity<ItemPedido>(new itemPedidoMapping().configure);
            builder.Entity<Pedido>(new pedidoMapping().configure);
            builder.Entity<UserMaster>(new userMasterMapping().configure);
        }
    }    
}