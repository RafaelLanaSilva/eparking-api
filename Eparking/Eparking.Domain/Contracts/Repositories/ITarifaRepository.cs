using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Contracts.Repositories
{
    public interface ITarifaRepository : IBaseRepository<Tarifa>
    {
        List<Tarifa>? ObterPorEstacionamentoId(Guid estacionamentoId);
        Tarifa? ObterPorEstacionamentoETipo(Guid estacionamentoId, TipoVeiculo tipo);
        Tarifa? ObterPorTipoVeiculo(Guid estacionamentoId, TipoVeiculo tipoVeiculo);
        Tarifa? ObterTarifaPorId(Guid id);
    }
}
