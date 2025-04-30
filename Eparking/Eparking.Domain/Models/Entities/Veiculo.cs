using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Models.Entities
{
    public class Veiculo
    {

        #region Propriedades

        public Guid? Id { get; set; }
        public string? Modelo { get; set; }
        public string? Placa { get; set; }
        public string? Cor { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }

        #endregion

        #region Relacionamentos

        public ICollection<Movimentacao>? Movimentacoes { get; set; }

        #endregion

    }

}
