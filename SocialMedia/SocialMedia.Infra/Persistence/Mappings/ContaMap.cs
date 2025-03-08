using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infra.Persistence.Mappings
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeCompleto)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(c => c.Senha)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .IsRequired();

            builder.HasMany(c => c.Perfis)
                .WithOne(p => p.Conta)
                .HasForeignKey(p => p.IdConta)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => c.Email)
                .HasDatabaseName("IX_Conta_Email");
        }
    }
}
