using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suporte.Entity;

namespace Back_end.Mapping {
    public class categoriaMapping : IEntityTypeConfiguration<Categoria> {
        public void Configure(EntityTypeBuilder<Categoria> builder) {
            builder.ToTable("ItemPedido");

            builder.HasKey(p => p.ProdutoId);
            builder.Property(p => p.PedidoId);

            builder.HasMany<Produto>(p => p.Produto).WithMany(p => p.ItemPedido).HasForeignKey(p => p.ProdutoId);
            builder.HasMany<Pedido>(p => p.Pedido).WithMany(p => p.ItemPedido).HasForeignKey(p => p.PedidoId);
        }
    }
}