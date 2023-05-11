using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public ICollection<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor, int diasPagamento, List<Item> itens)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Itens = new List<Item>();
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
            CondicaoPagamento = new CondicaoPagamento(diasPagamento);
            TotalGeral = new Money(0);
            itens?.ForEach(x => { AdicionarItem(x.Produto, x.Qtde); });
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Item item = new Item(produto, qtde);
            item.SolicitacaoCompraId = Id;
            Itens.Add(item);
            TotalGeral = TotalGeral.Add(item.Subtotal);
            if (TotalGeral.Value >= 5000) CondicaoPagamento = new CondicaoPagamento(30);
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (!Itens.Any()) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");

            AddEvent(new CompraRegistradaEvent(Id, itens, TotalGeral.Value));
        }
    }
}
