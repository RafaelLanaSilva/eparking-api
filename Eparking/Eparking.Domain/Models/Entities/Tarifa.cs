using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Models.Entities
{
    public class Tarifa
    {
        #region Propriedades

        public Guid Id { get; set; }
        public Guid EstacionamentoId { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public decimal? ValorHora { get; set; }
        public decimal? ValorFracao { get; set;} = null;
        public int? ToleranciaMinutos { get; set; }

        #endregion

        #region Relacionamentos

        public Estacionamento? Estacionamento { get; set; }

        #endregion

    }
}
