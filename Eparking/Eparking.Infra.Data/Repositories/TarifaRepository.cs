using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;
using Eparking.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eparking.Infra.Data.Repositories
{
    public class TarifaRepository: BaseRepository<Tarifa>, ITarifaRepository
    {
        public Tarifa? ObterPorEstacionamentoETipo(Guid estacionamentoId, TipoVeiculo tipo)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarifa>()
                    .Include(e => e.Estacionamento)
                    .FirstOrDefault(t => t.EstacionamentoId == estacionamentoId && t.TipoVeiculo == tipo);
            }
        }

        public List<Tarifa>? ObterPorEstacionamentoId(Guid estacionamentoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarifa>()
                    .Include(e => e.Estacionamento)
                    .Where(t => t.EstacionamentoId == estacionamentoId)
                    .ToList();
            }
        }

        public Tarifa? ObterPorTipoVeiculo(Guid estacionamentoId, TipoVeiculo tipoVeiculo)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarifa>()
                    .Include(e => e.Estacionamento)
                    .FirstOrDefault(t => t.EstacionamentoId == estacionamentoId && t.TipoVeiculo == tipoVeiculo);
            }
        }

        public Tarifa? ObterTarifaPorId(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarifa>()
                    .Include(e => e.Estacionamento)
                    .FirstOrDefault(t => t.Id == id);
            }
        }
    }
}
