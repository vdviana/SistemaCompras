using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class CompletandoFluxoSolicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("bbd99e39-6c8e-49b8-9cbd-53123bd026dc"));

            migrationBuilder.DeleteData(
                table: "SolicitacaoCompra",
                keyColumn: "Id",
                keyValue: new Guid("cdcc6da3-7656-4f8f-8faa-17f0d7c0e9d4"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("880c94fa-cfd3-436b-9fa4-ef1512b92aef"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.InsertData(
                table: "SolicitacaoCompra",
                columns: new[] { "Id", "CondicaoPagamento", "Data", "NomeFornecedor", "Situacao", "TotalGeral", "UsuarioSolicitante" },
                values: new object[] { new Guid("93ed395c-9c84-4005-abba-f46cb4d76e3e"), 30, new DateTime(2023, 5, 11, 3, 51, 36, 95, DateTimeKind.Local).AddTicks(1265), "Vendor012345", 1, 0m, "User012345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("880c94fa-cfd3-436b-9fa4-ef1512b92aef"));

            migrationBuilder.DeleteData(
                table: "SolicitacaoCompra",
                keyColumn: "Id",
                keyValue: new Guid("93ed395c-9c84-4005-abba-f46cb4d76e3e"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("bbd99e39-6c8e-49b8-9cbd-53123bd026dc"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.InsertData(
                table: "SolicitacaoCompra",
                columns: new[] { "Id", "CondicaoPagamento", "Data", "NomeFornecedor", "Situacao", "TotalGeral", "UsuarioSolicitante" },
                values: new object[] { new Guid("cdcc6da3-7656-4f8f-8faa-17f0d7c0e9d4"), 30, new DateTime(2023, 5, 11, 3, 17, 23, 335, DateTimeKind.Local).AddTicks(7139), "Vendor012345", 1, 0m, "User012345" });
        }
    }
}
