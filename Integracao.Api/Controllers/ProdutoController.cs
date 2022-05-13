using Integracao.Api.DTOs;
using Integracao.Domain.Entities;
using Integracao.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Integracao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(
            ILogger<ProdutoController> logger,
            IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterProdutos()
        {
            try
            {
                var response = await _produtoRepository.ObterTodos();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Falha ao carregar produtos");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] InserirProdutoDto request)
        {
            try
            {
                var produtoExistente = await _produtoRepository.ObterPorCodigoBarras(request.CodigoBarras);
                if (produtoExistente != null)
                    return BadRequest($"Código de barras ${produtoExistente.CodigoBarras} já cadastrado");

                var produto = new Produto(Guid.NewGuid(), request.CodigoBarras, request.NomeProduto, request.Quantidade, request.PrecoCompra, request.Lucro);
                await _produtoRepository.Inserir(produto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Falha ao cadastrar o produto");
            }
        }
    }
}
