using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.Data.EntityTypeConfigs
{
    public class FuncionarioEntityTypeConfig : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.FuncionarioId);

            builder.Property(f => f.NomeTratamento)
                .HasColumnType("varchar(" + Funcionario.NomeTratamentoMaxLength.ToString() + ")");

            builder.Property(f => f.CPF)
                .HasColumnType("varchar(" + Funcionario.CPFMaxLength.ToString() + ")")
                .IsRequired();
        }
    }
}
