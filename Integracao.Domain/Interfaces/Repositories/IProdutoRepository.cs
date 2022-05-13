using Integracao.Domain.Entities;

namespace Integracao.Domain.Repositories
{
    public interface IProdutoRepository : IDisposable
    {
        Task<List<Produto>> ObterTodos();
        Task<Produto?> ObterPorCodigoBarras(string codigoBarras);
        Task<Produto> ObterPorId(Guid id);
        Task Inserir(Produto produto);
        Task Atualizar(Produto produto);
    }
}
