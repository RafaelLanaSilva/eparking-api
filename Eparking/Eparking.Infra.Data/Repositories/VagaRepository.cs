using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;
using Eparking.Infra.Data.Context;

namespace Eparking.Infra.Data.Repositories
{
    public class VagaRepository : BaseRepository<Vaga>, IVagaRepository
    {
        public List<Vaga>? ObterVagasDisponiveis(Guid estacionamentoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Vaga>()
                    .Where(v => v.EstacionamentoId == estacionamentoId && v.Ocupado == false)
                    .ToList();
            }
        }

        public List<Vaga>? ObterVagasOcupadas(Guid estacionamentoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Vaga>()
                    .Where(v => v.EstacionamentoId == estacionamentoId && v.Ocupado == true)
                    .ToList();
            }
        }

        public List<Vaga>? ObterVagasPorTipo(TipoVaga tipoVaga)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Vaga>()
                    .Where(v => v.TipoVaga == tipoVaga)
                    .ToList();
            }
        }

        public Vaga? ObterPorNúmero(Guid estacionamentoId, int numero)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Vaga>()
                    .FirstOrDefault(v => v.EstacionamentoId == estacionamentoId && v.Numero == numero);
            }
        }

        public Vaga? ObterVagaPorId(Guid id)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Vaga>()
                    .FirstOrDefault(v => v.Id == id);
            }
        }
    }
}
