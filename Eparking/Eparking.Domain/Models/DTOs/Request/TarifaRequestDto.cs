using Eparking.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Eparking.Domain.Models.DTOs.Request
{
    public class TarifaRequestDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid EstacionamentoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EnumDataType(typeof(TipoVeiculo), ErrorMessage = "O campo {0} deve ser um valor válido.")]
        public TipoVeiculo? TipoVeiculo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal? ValorHora { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal? ValorFracao { get; set; } = null;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime? ToleranciaMinutos { get; set; }
    }
}
