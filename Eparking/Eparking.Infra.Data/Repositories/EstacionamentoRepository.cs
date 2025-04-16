using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Models.Entities;
using Eparking.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eparking.Infra.Data.Repositories
{
    public class EstacionamentoRepository : BaseRepository<Estacionamento>, IEstacionamentoRepository
    {
        public Estacionamento? ObterPorId(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Estacionamento>()
                    .FirstOrDefault(e => e.Id == id);
            }
        }

        public List<Estacionamento> ObterPorNome(string nome)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Estacionamento>()
                    .Where(e => e.Nome == nome)
                    .ToList();
            }
        }

        public Estacionamento? ObterComVagas(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Estacionamento>()
                    .Include(v => v.Vagas)
                    .FirstOrDefault(e => e.Id == id);
            }
        }
    }
}
