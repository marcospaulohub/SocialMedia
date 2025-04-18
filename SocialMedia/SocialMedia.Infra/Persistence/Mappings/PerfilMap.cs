﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infra.Persistence.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeExibicao)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(p => p.Sobre)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(p => p.Foto)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(p => p.Localidade)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.Profissao)
                .HasColumnType("varchar(150)")
                .IsRequired();
        }
    }
}
