using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Models.DTOs.Response
{
    public class VeiculoResponseDto
    {
        public Guid? Id { get; set; }
        public string? Modelo { get; set; }
        public string? Placa { get; set; }
        public string? Cor { get; set; }
        public TipoVeiculo? TipoVeiculo { get; set; }
    }
}
