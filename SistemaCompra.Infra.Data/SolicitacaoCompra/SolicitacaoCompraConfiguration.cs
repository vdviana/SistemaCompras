using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SistemaCompraAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SistemaCompraAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");

            builder.Property(p => p.TotalGeral)
           .HasColumnName("TotalGeral")
           .HasConversion(m => m.Value, v => new Money(v));

            builder.Property(p => p.CondicaoPagamento)
            .HasColumnName("CondicaoPagamento")
            .HasConversion(m => m.Valor, v => new CondicaoPagamento(v));

            builder.Property(p => p.NomeFornecedor)
          .HasColumnName("NomeFornecedor")
          .HasConversion(m => m.Nome, n => new NomeFornecedor(n));

            builder.Property(p => p.UsuarioSolicitante)
          .HasColumnName("UsuarioSolicitante")
          .HasConversion(m => m.Nome, n => new UsuarioSolicitante(n));

            builder.HasMany<SistemaCompraAgg.Item>("Itens");



        }
    }
}
