using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;
using Eparking.Infra.Data.Context;

namespace Eparking.Infra.Data.Repositories
{
    public class TarifaRepository: BaseRepository<Tarifa>, ITarifaRepository
    {
        public List<Tarifa>? ObterPorEstacionamentoId(Guid estacionamentoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarifa>()
                    .Where(t => t.EstacionamentoId == estacionamentoId)
                    .ToList();
            }
        }

        public Tarifa? ObterPorTipoVeiculo(Guid estacionamentoId, TipoVeiculo tipoVeiculo)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarifa>()
                    .FirstOrDefault(t => t.EstacionamentoId == estacionamentoId && t.TipoVeiculo == tipoVeiculo);
            }
        }

        public Tarifa? ObterTarifaPorId(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarifa>()
                    .FirstOrDefault(t => t.Id == id);
            }
        }
    }
}
