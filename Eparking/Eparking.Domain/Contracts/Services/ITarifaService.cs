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
    public interface ITarifaService
    {
        TarifaResponseDto Criar(TarifaRequestDto request);
        TarifaResponseDto Atualizar(Guid id, TarifaRequestDto request);
        TarifaResponseDto Excluir(Guid id);
        TarifaResponseDto? ObterPorId(Guid id);
        List<TarifaResponseDto> ObterTodos();
        List<TarifaResponseDto> ObterPorEstacionamento(Guid estacionamentoId);
        List<TarifaResponseDto> ObterPorTipoVeiculo(Guid estacionamentoId, TipoVeiculo tipoVeiculo);

    }
}
