using Integracao.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integracao.Domain.Entities
{
    [Table(name: "ProdutoIntegracao")]
    public class ProdutoIntegracao
    {
        public ProdutoIntegracao(Guid id, string codigoBarras, string nomeProduto, decimal quantidade, decimal precoCusto, EStatusIntegracao status)
        {
            Id = id;
            CodigoBarras = codigoBarras;
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            PrecoCusto = precoCusto;
            Status = status;
        }

        [Key]
        [Required]
        public Guid Id { get; private set; }

        [Required]
        public string CodigoBarras { get; private set; }

        [Required]
        public string NomeProduto { get; private set; }

        [Required]
        public decimal Quantidade { get; private set; }

        [Required]
        public decimal PrecoCusto { get; private set; }

        [Required]
        public EStatusIntegracao Status { get; private set; }

        public void FinalizarIntegracao() =>
            Status = EStatusIntegracao.IntegracaoConcluida;
    }
}
