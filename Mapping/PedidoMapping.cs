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
            builder.ToTable("Pedido");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGenerateOnAdd();
            builder.Property(p => p.ClienteId);
            builder.Property(p => p.Preco);
            builder.Property(p => p.Status);

            builder.HasOne<Cliente>(p => p.Cliente).WithMany(p => p.Pedido).HasForeignKey(p => p.Id);

        }
    }
}
