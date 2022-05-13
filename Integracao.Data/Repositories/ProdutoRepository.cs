using Integracao.Data.Context;
using Integracao.Domain.Entities;
using Integracao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Integracao.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IntegracaoContext _context;

        public ProdutoRepository(IntegracaoContext context)
        {
            _context = context;
        }


        public async Task<List<Produto>> ObterTodos() =>
            await _context.Produtos.AsNoTracking().ToListAsync();

        public async Task Atualizar(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto?> ObterPorCodigoBarras(string codigoBarras) =>
            await _context.Produtos
                .AsNoTracking()
                .Where(x => string.Equals(x.CodigoBarras, codigoBarras))
                .FirstOrDefaultAsync();

        public async Task<Produto> ObterPorId(Guid id) =>
            await _context
                .Produtos
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstAsync();

        public void Dispose() =>
            _context.Dispose();
    }
}
