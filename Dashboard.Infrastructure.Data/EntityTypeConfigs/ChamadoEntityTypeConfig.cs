using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.Data.EntityTypeConfigs
{
    public class ChamadoEntityTypeConfig : IEntityTypeConfiguration<Chamado>
    {
        public void Configure(EntityTypeBuilder<Chamado> builder)
        {
            builder.HasKey(c => c.ChamadoId);

            builder.Property(e => e.Status)
                .HasColumnType("varchar(" + Chamado.StatusMaxLength.ToString() + ")")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnType("varchar(" + Chamado.DescricaoMaxLength.ToString() + ")")
                .IsRequired();
            
            builder.Property(e => e.Responsavel)
                .HasColumnType("varchar(" + Chamado.ResponsavelMaxLength.ToString() + ")");
        }
    }
}
