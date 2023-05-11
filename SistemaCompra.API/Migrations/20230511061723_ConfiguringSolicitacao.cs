using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class ConfiguringSolicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("e020e3d3-a218-43be-bda9-49f700d039a9"));

            migrationBuilder.DeleteData(
                table: "SolicitacaoCompra",
                keyColumn: "Id",
                keyValue: new Guid("e37b187b-b365-4942-8f3b-122589662307"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("bbd99e39-6c8e-49b8-9cbd-53123bd026dc"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.InsertData(
                table: "SolicitacaoCompra",
                columns: new[] { "Id", "CondicaoPagamento", "Data", "NomeFornecedor", "Situacao", "TotalGeral", "UsuarioSolicitante" },
                values: new object[] { new Guid("cdcc6da3-7656-4f8f-8faa-17f0d7c0e9d4"), 30, new DateTime(2023, 5, 11, 3, 17, 23, 335, DateTimeKind.Local).AddTicks(7139), "Vendor012345", 1, 0m, "User012345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("e020e3d3-a218-43be-bda9-49f700d039a9"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.InsertData(
                table: "SolicitacaoCompra",
                columns: new[] { "Id", "CondicaoPagamento", "Data", "NomeFornecedor", "Situacao", "TotalGeral", "UsuarioSolicitante" },
                values: new object[] { new Guid("e37b187b-b365-4942-8f3b-122589662307"), 30, new DateTime(2023, 5, 11, 3, 13, 39, 203, DateTimeKind.Local).AddTicks(5064), "Vendor012345", 1, 0m, "User012345" });
        }
    }
}
