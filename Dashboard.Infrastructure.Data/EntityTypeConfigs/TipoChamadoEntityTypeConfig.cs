using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Infrastructure.Data.EntityTypeConfigs
{
    class TipoChamadoEntityTypeConfig : IEntityTypeConfiguration<TipoChamado>
    {
        public void Configure(EntityTypeBuilder<TipoChamado> builder)
        {
            builder.HasKey(t => t.TipoChamadoId);

            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasColumnType("varchar(" + TipoChamado.DescricaoMaxLength.ToString() + ")");
        }
    }
}
