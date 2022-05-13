using Integracao.Data.Context;
using Integracao.Domain.Entities;
using Integracao.Domain.Enums;
using Integracao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Integracao.Data.Repositories
{
    public class ProdutoIntegracaoRepository : IProdutoIntegracaoRepository
    {
        private readonly IntegracaoContext _context;

        public ProdutoIntegracaoRepository(IntegracaoContext context)
        {
            _context = context;
        }

        public async Task<ProdutoIntegracao> ObterPorId(Guid id) =>
            await _context.ProdutosIntegracoes.Where(x => x.Id == id).FirstAsync();

        public async Task Atualizar(ProdutoIntegracao produtoIntegracao)
        {
            _context.Entry<ProdutoIntegracao>(produtoIntegracao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(ProdutoIntegracao produtoIntegracao)
        {
            _context.Add(produtoIntegracao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProdutoIntegracao>> ObterProdutosParaIntegrar() =>
            await _context.ProdutosIntegracoes
                .AsNoTracking()
                .Where(x => x.Status == EStatusIntegracao.AguardandoIntegracao)
                .ToListAsync();

        public void Dispose() =>
            _context.Dispose();
    }
}
