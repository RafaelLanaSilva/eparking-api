using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Models.Entities;
using Eparking.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eparking.Infra.Data.Repositories
{
    public class MovimentacaoRepository : BaseRepository<Movimentacao>, IMovimentacaoRepository
    {
        public Movimentacao? ObterPorId(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Movimentacao>()
                    .FirstOrDefault(m => m.Id == id);
            }
        }

        public List<Movimentacao> ObterPorEstacionamento(Guid estacionamentoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Movimentacao>()
                    .Where(m => m.EstacionamentoId == estacionamentoId)
                    .Include(e => e.Estacionamento)
                    .ToList();
            }
        }

        public List<Movimentacao> ObterPorVaga(Guid vagaId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Movimentacao>()
                    .Where(m => m.VagaId == vagaId)
                    .Include(v => v.Vaga)
                    .ToList();
            }
        }

        public List<Movimentacao> ObterPorVeiculo(Guid veiculoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Movimentacao>()
                    .Where(m => m.VeiculoId == veiculoId)
                    .Include(v => v.Veiculo)
                    .ToList();
            }
        }

        public List<Movimentacao> ObterEmAberto()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Movimentacao>()
                    .Where(m => m.HoraSaida == null)
                    .Include(v => v.Veiculo)
                    .Include(e => e.Estacionamento)
                    .ToList();
            }
        }
    }
}
