using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eparking.Domain.Models.DTOs.Response
{
    public class EstacionamentoComVagasResponseDto : EstacionamentoResponseDto
    {
        public List<VagaResponseDto>? Vagas { get; set; }
    }
}
