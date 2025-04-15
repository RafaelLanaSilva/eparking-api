using Eparking.Domain.Models.Entities;

namespace Eparking.Domain.Contracts.Repositories
{
    public interface IEstacionamentoRepository : IBaseRepository<Estacionamento>
    {
        Estacionamento? ObterPorId(Guid id);
        List<Estacionamento> ObterPorNome(string nome);
        Estacionamento? ObterComVagas(Guid id);
    }
}
