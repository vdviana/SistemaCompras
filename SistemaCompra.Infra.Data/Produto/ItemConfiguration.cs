using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class ItemConfiguration : IEntityTypeConfiguration<SolicitacaoAgg.Item>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAgg.Item> builder)
        {
            builder.ToTable("Item");
            builder.HasOne<ProdutoAgg.Produto>("Produto");
        }
    }

}
