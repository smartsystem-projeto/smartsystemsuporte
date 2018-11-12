using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.Data.EntityTypeConfigs
{
    public class UsuarioEntityTypeConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.UsuarioId);

            builder.Property(u => u.Login)
                .HasColumnType("varchar("+Usuario.LoginMaxLength.ToString()+")")
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnType("varchar(" + Usuario.SenhaMaxLength.ToString() + ")")
                .IsRequired();

            builder.Property(u => u.Nome)
                .HasColumnType("varchar(" + Usuario.NomeMaxLength.ToString() + ")")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType("varchar(" + Usuario.EmailMaxLength.ToString() + ")")
                .IsRequired();

            builder.Property(u => u.Nivel)
                .HasColumnType("varchar(" + Usuario.NivelMaxLength.ToString() + ")")
                .IsRequired();
        }
    }
}
