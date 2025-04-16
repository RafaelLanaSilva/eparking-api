using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;
using Eparking.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eparking.Infra.Data.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public Veiculo? ObterPorPlaca(string placa)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Veiculo>()
                    .FirstOrDefault(c => c.Placa != null && c.Placa.ToUpper() == placa.ToUpper().Trim());
            }
        }

        public Veiculo? ObterPorId(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Veiculo>()
                    .FirstOrDefault (c => c.Id == id);
            }
        }

        public List<Veiculo>? ObterVeiculosPorTipo(TipoVeiculo tipoVeiculo)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Veiculo>()
                    .Where(v => v.TipoVeiculo == tipoVeiculo)
                    .ToList();
            }
        }

        public List<Veiculo>? ObterVeiculosComMovimentacoes()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Veiculo>()
                    .Include(v => v.Movimentacoes)  
                    .ToList();
            }
        }
    }
}
