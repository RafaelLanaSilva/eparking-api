﻿using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Contracts.Repositories
{
    public interface IVagaRepository : IBaseRepository<Vaga>
    {
        List<Vaga>? ObterVagasDisponiveis(Guid estacionamentoId);
        List<Vaga>? ObterVagasOcupadas(Guid estacionamentoId);
        List<Vaga>? ObterVagasPorTipo(TipoVaga tipoVaga);   
        Vaga? ObterPorNúmero(Guid estacionamentoId, int numero);
    }
}
