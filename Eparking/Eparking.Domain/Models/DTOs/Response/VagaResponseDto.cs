using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Models.DTOs.Response
{
    public class VagaResponseDto
    {
        public Guid Id { get; set; }
        public int? Numero { get; set; }
        public TipoVaga? TipoVaga { get; set; }
        public bool Ocupado { get; set; } = false;
        public Guid EstacionamentoId { get; set; }
    }
}
