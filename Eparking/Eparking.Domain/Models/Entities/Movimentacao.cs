namespace Eparking.Domain.Models.Entities
{
    public class Movimentacao
    {
        #region Propriedades

        public Guid Id { get; set; }
        public Guid EstacionamentoId { get; set; }
        public Guid VagaId { get; set; }
        public Guid VeiculoId { get; set; }
        public DateTime? HoraEntrada { get; set; }
        public DateTime? HoraSaida { get; set; }
        public decimal? ValorCobrado { get; set; }

        #endregion

        #region Relacionamentos

        public Vaga? Vaga { get; set; }
        public Veiculo? Veiculo { get; set; }
        public Estacionamento? Estacionamento { get; set; }

        #endregion
    }
}
