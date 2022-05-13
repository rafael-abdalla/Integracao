using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integracao.Domain.Entities
{
    [Table(name: "Produto")]
    public class Produto
    {
        public Produto(Guid id, string codigoBarras, string nomeProduto, decimal quantidade, decimal precoCompra, decimal lucro)
        {
            Id = id;
            CodigoBarras = codigoBarras;
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            PrecoCompra = precoCompra;
            PrecoVenda = precoCompra + (precoCompra * (lucro / 100));
            Lucro = lucro;
        }

        public Produto(Guid id, string codigoBarras, string nomeProduto, decimal quantidade, decimal precoCompra, decimal precoVenda, decimal lucro)
        {
            Id = id;
            CodigoBarras = codigoBarras;
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            PrecoCompra = precoCompra;
            PrecoVenda = precoVenda;
            Lucro = lucro;
        }

        [Key]
        public Guid Id { get; private set; }

        [Required, MaxLength(14)]
        public string CodigoBarras { get; private set; }

        [Required, MaxLength(200)]
        public string NomeProduto { get; private set; }

        [Required]
        public decimal Quantidade { get; private set; }

        [Required]
        public decimal PrecoCompra { get; private set; }

        [Required]
        public decimal PrecoVenda { get; private set; }

        [Required]
        public decimal Lucro { get; private set; }

        public void AtualizarDados(ProdutoIntegracao produtoParaIntegrar)
        {
            Quantidade += produtoParaIntegrar.Quantidade;
            PrecoCompra = produtoParaIntegrar.PrecoCusto;
            PrecoVenda = produtoParaIntegrar.PrecoCusto + (produtoParaIntegrar.PrecoCusto * (Lucro / 100));
        }
    }
}
