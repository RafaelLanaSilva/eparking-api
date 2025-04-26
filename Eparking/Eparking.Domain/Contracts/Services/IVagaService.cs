using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eparking.Domain.Contracts.Services
{
    public interface IVagaService
    {
        VagaResponseDto Criar(VagaRequestDto request);
        VagaResponseDto Atualizar(Guid id, VagaRequestDto request);
        VagaResponseDto Excluir(Guid id);
        VagaResponseDto? ObterPorId(Guid id);
        List<VagaResponseDto> ObterPorEstacionamento(Guid estacionamentoId);
        List<VagaResponseDto> ObterPorTipo(TipoVaga tipoVaga);
        List<VagaResponseDto> ObterOcupadasPorEstacionamento(Guid estacionamentoId);
        List<VagaResponseDto> ObterDisponiveisPorEstacionamento(Guid estacionamentoId);

    }
}
