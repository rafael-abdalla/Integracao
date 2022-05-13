using Integracao.Domain.Entities;

namespace Integracao.Domain.Repositories
{
    public interface IProdutoIntegracaoRepository : IDisposable
    {
        Task<List<ProdutoIntegracao>> ObterProdutosParaIntegrar();
        Task<ProdutoIntegracao> ObterPorId(Guid id);
        Task Inserir(ProdutoIntegracao produtoIntegracao);
        Task Atualizar(ProdutoIntegracao produtoIntegracao);
    }
}
