using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.Data.EntityTypeConfigs
{
    public class EnderecoEntityTypeConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.EnderecoId);

            builder.Property(e => e.Rua)
                .HasColumnType("varchar(" + Endereco.RuaMaxLength.ToString() + ")")
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasColumnType("varchar(" + Endereco.BairroMaxLength.ToString() + ")");

            builder.Property(e => e.Cidade)
                .HasColumnType("varchar(" + Endereco.CidadeMaxLength.ToString() + ")")
                .IsRequired();

            builder.Property(e => e.UF)
                .HasColumnType("varchar(" + Endereco.UFMaxLength.ToString() + ")");
        }
    }
}
