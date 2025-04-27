namespace Eparking.Domain.Models.DTOs.Response
{
    public class EstacionamentoComVagasResponseDto : EstacionamentoResponseDto
    {
        public List<VagaResponseDto>? Vagas { get; set; }
    }
}
