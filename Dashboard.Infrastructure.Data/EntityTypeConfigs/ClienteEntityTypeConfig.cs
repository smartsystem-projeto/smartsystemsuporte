using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.Data.EntityTypeConfigs
{
    public class ClienteEntityTypeConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.ClienteId);

            builder.Property(c => c.RazaoSocial)
                .HasColumnType("varchar(" + Cliente.RazaoSocialMaxLength.ToString() + ")")
                .IsRequired();

            builder.Property(c => c.NomeFantasia)
                .HasColumnType("varchar(" + Cliente.NomeFantasiaMaxLength.ToString() + ")")
                .IsRequired();

            builder.Property(c => c.CNPJ)
                .HasColumnType("varchar(" + Cliente.CNPJMaxLength.ToString() + ")");

            builder.Property(c => c.CPF)
                .HasColumnType("varchar(" + Cliente.CPFMaxLength.ToString() + ")");

            builder.Property(c => c.Email)
                .HasColumnType("varchar(" + Cliente.EmailMaxLength.ToString() + ")")
                .IsRequired();
        }
    }
}
