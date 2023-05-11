using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.Produto;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions options) : base(options) { }
        public DbSet<ProdutoAgg.Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfiguration(new SolicitacaoCompraConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            ProdutoAgg.Produto produto = new ProdutoAgg.Produto("Produto01", "Descricao01", "Madeira", 100);
            Item item = new Item(produto, 10);

            modelBuilder.Entity<ProdutoAgg.Produto>()
             .HasData(produto);

            SolicitacaoAgg.SolicitacaoCompra solicitacaocompra = new SolicitacaoAgg.SolicitacaoCompra("User012345", "Vendor012345", 30, new System.Collections.Generic.List<Item>());

            modelBuilder.Entity<SolicitacaoAgg.SolicitacaoCompra>()
               .HasData(solicitacaocompra);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=SistemaCompraDb;User Id=sa2;Password=123456;TrustServerCertificate=True;");
        }
    }
}
