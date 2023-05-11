using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string NomeUsuario { get; set; }
        public string NomeFornecedor { get; set; }
        public int DiasPagamento { get; set; }
        public List<Item> Itens { get; set; }

    }
}
