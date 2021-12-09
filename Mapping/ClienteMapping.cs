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
            builder.ToTable("Cliente");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGenerateOnAdd();
            builder.Property(p => p.Nome).HasMaxLength(70);
            builder.Property(p => p.Cpf).HasMaxLength(13);
            builder.Property(p => p.DataNascimento);
            builder.Property(p => p.Email).HasMaxLength(256);
            builder.Property(p => p.Senha).HasMaxLength(50);
            builder.Property(p => p.Perfil).HasMaxLength(70);
            builder.Property(p => p.Endereco_rua).HasMaxLength(200);
            builder.Property(p => p.Endereco_numero).HasMaxLength(5);
            builder.Property(p => p.Endereco_complemento).HasMaxLength(100);
            builder.Property(p => p.Endereco_bairro).HasMaxLength(200);
            builder.Property(p => p.Endereco_cidade).HasMaxLength(100);
            builder.Property(p => p.Endereco_cep).HasMaxLength(20);
        }
    }
}