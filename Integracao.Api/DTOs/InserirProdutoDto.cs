using System.ComponentModel.DataAnnotations;

namespace Integracao.Api.DTOs
{
    public class InserirProdutoDto
    {
        public InserirProdutoDto(string codigoBarras, string nomeProduto, decimal quantidade, decimal precoCompra, decimal lucro)
        {
            CodigoBarras = codigoBarras;
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            PrecoCompra = precoCompra;
            Lucro = lucro;
        }

        [Required(ErrorMessage = "Código de barras obrigatório")]
        [MaxLength(14, ErrorMessage = "Máximo de 14 dígitos")]
        public string CodigoBarras { get; set; }

        [Required(ErrorMessage = "Código de barras obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 dígitos")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "Quantidade obrigatória")]
        public decimal Quantidade { get; set; }

        [Required(ErrorMessage = "Preço de compra obrigatório")]
        public decimal PrecoCompra { get; set; }

        [Required(ErrorMessage = "Lucro obrigatório")]
        public decimal Lucro { get; set; }
    }
}
