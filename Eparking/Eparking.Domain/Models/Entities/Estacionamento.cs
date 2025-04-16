namespace Eparking.Domain.Models.Entities
{
    public class Estacionamento
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public int? QuantidadeVagasCarro { get; set; }
        public int? QuantidadeVagasMotocicleta { get; set; }
        public int? QuantidadeVagasPreferencial { get; set; }

        #endregion

        #region Relacionamentos

        public ICollection<Movimentacao>? Movimentacoes { get; set; }
        public ICollection<Vaga>? Vagas { get; set; }
        public ICollection<Tarifa>? Tarifas { get; set; }

        #endregion
    }
}
