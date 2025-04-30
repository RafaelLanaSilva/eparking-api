using Eparking.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Eparking.Domain.Models.DTOs.Request
{
    public class TarifaRequestDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid EstacionamentoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public TipoVeiculo? TipoVeiculo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal? ValorHora { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal? ValorFracao { get; set; } = null;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int? ToleranciaMinutos { get; set; }
    }
}
