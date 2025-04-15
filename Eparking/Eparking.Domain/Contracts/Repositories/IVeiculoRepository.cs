using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Contracts.Repositories
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Veiculo? ObterPorPlaca(string placa);
        Veiculo? ObterPorId(Guid id);
        List<Veiculo>? ObterVeiculosPorTipo(TipoVeiculo tipoVeiculo);
        List<Veiculo>? ObterVeiculosComMovimentacoes();
    }
}
