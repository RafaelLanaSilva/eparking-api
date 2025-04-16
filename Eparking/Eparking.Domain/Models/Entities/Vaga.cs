using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Models.Entities
{
    public class Vaga
    {
        #region Propriedades

        public Guid Id { get; set; }
        public int? Numero { get; set; }
        public TipoVaga? TipoVaga { get; set; }
        public bool Ocupado { get; set; } = false;
        public Guid EstacionamentoId { get; set; }

        #endregion

        #region Relacionamentos

        public ICollection<Movimentacao>? Movimentacoes { get; set; }
        public Estacionamento? Estacionamento { get; set; }

        #endregion
    }
}
