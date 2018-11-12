using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Infrastructure.Data.EntityTypeConfigs
{
    public class TelefoneEntityTypeConfig : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => t.TelefoneId);

            builder.Property(t => t.DDD)
                .HasMaxLength(Telefone.DDDMaxLength);

            builder.Property(t => t.Numero)
                .HasMaxLength(Telefone.NumeroMaxLength);
        }
    }
}
