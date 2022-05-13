using Integracao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Integracao.Data.Context
{
    public class IntegracaoContext : DbContext
    {
        public IntegracaoContext(DbContextOptions<IntegracaoContext> options) : base(options) { }


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoIntegracao> ProdutosIntegracoes { get; set; }
    }
}
