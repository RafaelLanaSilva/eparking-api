namespace Eparking.Domain.Models.DTOs.Response
{
    public class EstacionamentoResponseDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public int? QuantidadeVagasCarro { get; set; }
        public int? QuantidadeVagasMotocicleta { get; set; }
        public int? QuantidadeVagasPreferencial { get; set; }
    }
}
