using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.Data.EntityTypeConfigs
{
    public class PosicionamentoChamadoEntityTypeConfig : IEntityTypeConfiguration<PosicionamentoChamado>
    {
        public void Configure(EntityTypeBuilder<PosicionamentoChamado> builder)
        {
            builder.HasKey(p => p.PosicionamentoChamadoId);

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(" + PosicionamentoChamado.DescricaoMaxLength.ToString() + ")")
                .IsRequired();
        }
    }
}
