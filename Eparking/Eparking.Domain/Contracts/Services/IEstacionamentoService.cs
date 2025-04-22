using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eparking.Domain.Contracts.Services
{
    public interface IEstacionamentoService
    {
        EstacionamentoResponseDto Criar(EstacionamentoRequestDto request);
        EstacionamentoResponseDto Atualizar(Guid id, EstacionamentoRequestDto request);
        EstacionamentoResponseDto Excluir(Guid id);
        EstacionamentoResponseDto? ObterPorId(Guid id);
        List<EstacionamentoResponseDto> ObterTodos();
        List<EstacionamentoResponseDto> ObterPorNome(string nome);
        EstacionamentoResponseDto? ObterComVagas(Guid id);

    }
}
