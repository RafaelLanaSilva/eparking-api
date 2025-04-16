namespace Eparking.Domain.Models.DTOs.Response
{
    public class MovimentoResponseDto
    {
        public Guid Id { get; set; }
        public Guid EstacionamentoId { get; set; }
        public Guid VagaId { get; set; }
        public Guid VeiculoId { get; set; }
        public DateTime? HoraEntrada { get; set; }
        public DateTime? HoraSaida { get; set; }
        public decimal? ValorCobrado { get; set; }
    }
}
