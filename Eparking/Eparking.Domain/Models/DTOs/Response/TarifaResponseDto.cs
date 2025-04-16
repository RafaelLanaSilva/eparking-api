using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Models.DTOs.Response
{
    public class TarifaResponseDto
    {
        public Guid Id { get; set; }
        public Guid EstacionamentoId { get; set; }
        public TipoVeiculo? TipoVeiculo { get; set; }
        public decimal? ValorHora { get; set; }
        public decimal? ValorFracao { get; set; }
        public DateTime? ToleranciaMinutos { get; set; }
    }
}
