using System.ComponentModel.DataAnnotations;

namespace Integracao.Api.DTOs
{
    public class InserirProdutoIntegracaoDto
    {
        public InserirProdutoIntegracaoDto(string codigoBarras, string nomeProduto, decimal quantidade, decimal precoCusto)
        {
            CodigoBarras = codigoBarras;
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            PrecoCusto = precoCusto;
        }

        [Required(ErrorMessage = "Código de barras obrigatório")]
        [MaxLength(14, ErrorMessage = "Máximo de 14 dígitos")]
        public string CodigoBarras { get; set; }

        [Required(ErrorMessage = "Código de barras obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 dígitos")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "Quantidade obrigatória")]
        public decimal Quantidade { get; set; }

        [Required(ErrorMessage = "Preço de custo obrigatório")]
        public decimal PrecoCusto { get; set; }
    }
}
