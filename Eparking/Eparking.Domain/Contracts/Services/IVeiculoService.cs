using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Contracts.Services
{
    public interface IVeiculoService
    {
        VeiculoResponseDto Criar(VeiculoRequestDto request);
        VeiculoResponseDto Atualizar(Guid id, VeiculoRequestDto request);
        VeiculoResponseDto Excluir(Guid id);
        VeiculoResponseDto? ObterPorId(Guid id);
        List<VeiculoResponseDto> ObterTodos();
        VeiculoResponseDto? ObterPorPlaca(string placa);
        List<VeiculoResponseDto> ObterPorTipo(TipoVeiculo tipoVeiculo);
        List<VeiculoResponseDto> ObterComMovimentacoes();

    }
}
