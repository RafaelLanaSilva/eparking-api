using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eparking.Domain.Contracts.Services
{
    public interface IMovimentacaoService
    {
        MovimentacaoResponseDto Criar(MovimentacaoRequestDto request);
        MovimentacaoResponseDto Atualizar(Guid id, MovimentacaoRequestDto request);
        MovimentacaoResponseDto Excluir(Guid id);
        MovimentacaoResponseDto? ObterPorId(Guid id);
        List<MovimentacaoResponseDto> ObterTodos();
        List<MovimentacaoResponseDto> ObterHistoricoPorPlaca(string placa);
        List<MovimentacaoResponseDto> ObterPorEstacionamento(Guid estacionamentoId);
        List<MovimentacaoResponseDto> ObterPorVaga(Guid vagaId);
        List<MovimentacaoResponseDto> ObterPorVeiculo(Guid veiculoId);
        List<MovimentacaoResponseDto> ObterEmAberto();
        List<MovimentacaoResponseDto> ObterHistoricoPorDatas(DateTime dataInicio, DateTime dataFim);

    }
}
