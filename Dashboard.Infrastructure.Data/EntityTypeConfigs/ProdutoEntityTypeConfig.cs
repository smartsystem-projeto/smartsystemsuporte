using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.Data.EntityTypeConfigs
{
    public class ProdutoEntityTypeConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(u => u.ProdutoId);

            builder.Property(u => u.Nome)
                .HasColumnType("varchar(" + Produto.NomeMaxLength.ToString() + ")")
                .IsRequired();

            builder.Property(u => u.Descricao)
                .HasColumnType("varchar(" + Produto.DescricaoMaxLength.ToString() + ")");
        }
    }
}
