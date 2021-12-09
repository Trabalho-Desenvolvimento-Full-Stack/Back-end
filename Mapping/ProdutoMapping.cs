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
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGenerateOnAdd();
            builder.Property(p => p.Nome).HasMaxLength(200);
            builder.Property(p => p.Categoria);
            builder.Property(p => p.Preco);
            builder.Property(p => p.Titulo).HasMaxLength(100);
            builder.Property(p => p.Descricao).HasMaxLength(500);
            builder.Property(p => p.Imagem).HasMaxLength(4000);

            builder.HasOne<Produto>(p => p.Produto).WithMany(p => p.Categoria).HasForeignKey(p => p.id);
        }
    }
}
