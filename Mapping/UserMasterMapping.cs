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

            builder.Property(p => p.Nome).HasMaxLength(200);
            builder.Property(p => p.Cpf).HasMaxLength(13);
            builder.Property(p => p.Preco);
            builder.Property(p => p.Email).HasMaxLength(256);
            builder.Property(p => p.Senha).HasMaxLength(200);
        }
    }
}
