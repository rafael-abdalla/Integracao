using Integracao.Api.DTOs;
using Integracao.Domain.Entities;
using Integracao.Domain.Enums;
using Integracao.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Integracao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoIntegracaoController : ControllerBase
    {
        private readonly ILogger<ProdutoIntegracaoController> _logger;
        private readonly IProdutoIntegracaoRepository _produtoIntegracaoRepository;

        public ProdutoIntegracaoController(
            ILogger<ProdutoIntegracaoController> logger,
            IProdutoIntegracaoRepository produtoIntegracaoRepository)
        {
            _logger = logger;
            _produtoIntegracaoRepository = produtoIntegracaoRepository;
        }

        [HttpGet("produtos-para-integracao")]
        public async Task<IActionResult> ObterProdutosParaIntegracao()
        {
            try
            {
                var response = await _produtoIntegracaoRepository.ObterProdutosParaIntegrar();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Falha ao carregar produtos para integração");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] InserirProdutoIntegracaoDto request)
        {
            try
            {
                var integracao = new ProdutoIntegracao(Guid.NewGuid(), request.CodigoBarras, request.NomeProduto, request.Quantidade, request.PrecoCusto, EStatusIntegracao.AguardandoIntegracao);
                await _produtoIntegracaoRepository.Inserir(integracao);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Falha ao carregar produtos para integração");
            }
        }
    }
}
