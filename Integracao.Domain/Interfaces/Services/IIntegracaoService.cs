namespace Integracao.Domain.Interfaces.Services
{
    public interface IIntegracaoService : IDisposable
    {
        Task IntegrarProdutos();
    }
}
