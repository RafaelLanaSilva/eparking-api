using Eparking.Domain.Models.Entities;

namespace Eparking.Domain.Contracts.Repositories
{
    public interface IMovimentacaoRepository : IBaseRepository<Movimentacao>
    {
        Movimentacao? ObterPorId(Guid id);
        List<Movimentacao> ObterHistoricoPorPlaca(string placa);
        List<Movimentacao> ObterPorEstacionamento(Guid estacionamentoId);
        List<Movimentacao> ObterPorVaga(Guid vagaId);
        List<Movimentacao> ObterPorVeiculo(Guid veiculoId);
        List<Movimentacao> ObterHistoricoPorDatas(DateTime dataInicio, DateTime dataFim);
        List<Movimentacao> ObterEmAberto();
    }
}
