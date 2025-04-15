using Eparking.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eparking.Domain.Models.Entities
{
    public class Veiculo
    {
        public Guid? Id { get; set; }
        public string? Modelo { get; set; }
        public string? Placa { get; set; }
        public string? Cor { get; set; }
        public TipoVeiculo? TipoVeiculo { get; set; }

        #region Relacionamentos



        #endregion

    }

}
