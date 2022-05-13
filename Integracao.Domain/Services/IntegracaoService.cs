using Integracao.Domain.Entities;
using Integracao.Domain.Interfaces.Services;
using Integracao.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Integracao.Domain.Services
{
    public class IntegracaoService : IIntegracaoService
    {
        private readonly ILogger<IntegracaoService> _logger;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoIntegracaoRepository _produtoIntegracaoRepository;

        public IntegracaoService(
            ILogger<IntegracaoService> logger,
            IProdutoRepository produtoRepository,
            IProdutoIntegracaoRepository produtoIntegracaoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
            _produtoIntegracaoRepository = produtoIntegracaoRepository;
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
            _produtoIntegracaoRepository.Dispose();
        }

        public async Task IntegrarProdutos()
        {
            var produtosParaIntegrar = await _produtoIntegracaoRepository.ObterProdutosParaIntegrar();

            if (!produtosParaIntegrar.Any())
            {
                _logger.LogInformation("Nenhum produto para integrar");
                return;
            }

            foreach(var produtoParaIntegrar in produtosParaIntegrar)
            {
                _logger.LogInformation("Integração iniciada: {time}", DateTimeOffset.Now);

                var produtoExistente = await _produtoRepository.ObterPorCodigoBarras(produtoParaIntegrar.CodigoBarras);
                if (produtoExistente != null)
                {
                    var produto = await _produtoRepository.ObterPorId(produtoExistente.Id);

                    produto.AtualizarDados(produtoParaIntegrar);

                    await _produtoRepository.Atualizar(produto);

                    _logger.LogInformation($"Produto atualizado: Id {produtoExistente.Id} Código Barra {produtoExistente.CodigoBarras} Nome {produtoExistente.NomeProduto}");
                } 
                else
                {
                    // Lucro padrão de 20%
                    var produto = new Produto(Guid.NewGuid(), produtoParaIntegrar.CodigoBarras, produtoParaIntegrar.NomeProduto, produtoParaIntegrar.Quantidade, produtoParaIntegrar.PrecoCusto, 20);
                    await _produtoRepository.Inserir(produto);

                    _logger.LogInformation($"Produto integrado: Id {produto.Id} Código Barra {produto.CodigoBarras} Nome {produto.NomeProduto}");
                }

                produtoParaIntegrar.FinalizarIntegracao();

                await _produtoIntegracaoRepository.Atualizar(produtoParaIntegrar);

                _logger.LogInformation("Integração finalizada: {time}", DateTimeOffset.Now);
            }

        }
    }
}
