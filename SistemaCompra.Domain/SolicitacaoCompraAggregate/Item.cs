using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class Item : Entity
    {
        public Guid SolicitacaoCompraId { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Qtde { get; set; }

        public Money Subtotal => ObterSubtotal();

        public Item(Produto produto, int qtde)
        {
            Id = Guid.NewGuid();
            Produto = produto ?? throw new ArgumentNullException(nameof(produto));
            ProdutoId = produto.Id;
            Qtde = qtde;
        }

        private Money ObterSubtotal()
        {
            return new Money(Produto.Preco.Value * Qtde);
        }

        private Item() { }

    }
}
