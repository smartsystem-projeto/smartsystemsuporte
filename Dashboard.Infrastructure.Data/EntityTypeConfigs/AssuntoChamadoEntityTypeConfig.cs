using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Infrastructure.Data.EntityTypeConfigs
{
    public class AssuntoChamadoEntityTypeConfig : IEntityTypeConfiguration<AssuntoChamado>
    {
        public void Configure(EntityTypeBuilder<AssuntoChamado> builder)
        {
            builder.HasKey(atp => atp.AssuntoChamadoId);

            builder.Property(atp => atp.Descricao)
                .IsRequired()
                .HasColumnType("varchar(" + AssuntoChamado.DescricaoMaxLength.ToString() + ")");
        }
    }
}
