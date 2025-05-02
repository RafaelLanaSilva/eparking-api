using AutoMapper;
using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Entities;

namespace Eparking.Domain.Services
{
    public class MovimentacaoDomainService : IMovimentacaoService
    {
        #region Métodos Construtores

        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IVagaRepository _vagaRepository;
        private readonly ITarifaRepository _tarifaRepository;
        private readonly IMapper _mapper;

        public MovimentacaoDomainService(IMovimentacaoRepository movimentacaoRepository, IEstacionamentoRepository estacionamentoRepository, IVagaRepository vagaRepository, IMapper mapper, ITarifaRepository tarifaRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
            _estacionamentoRepository = estacionamentoRepository;
            _vagaRepository = vagaRepository;
            _mapper = mapper;
            _tarifaRepository = tarifaRepository;
        }

        #endregion

        #region Método Criar
        public MovimentacaoResponseDto Criar(MovimentacaoRequestDto request)
        {
            var estacionamentoExistente = _estacionamentoRepository.ObterPorId(request.EstacionamentoId);
            if (estacionamentoExistente == null)
            {
                throw new ApplicationException("Estacionamento não encontrado");
            }

            var vagaExistente = _vagaRepository.ObterVagaPorId(request.VagaId);
            if (vagaExistente == null)
            {
                throw new ApplicationException("Vaga não encontrada");
            }

            var movimentacao = _mapper.Map<Movimentacao>(request);
            movimentacao.Id = Guid.NewGuid();
            movimentacao.HoraEntrada = DateTime.UtcNow;
            movimentacao.HoraSaida = null;
            movimentacao.ValorCobrado = null;
            _movimentacaoRepository.Add(movimentacao);

            var response = _mapper.Map<MovimentacaoResponseDto>(movimentacao);
            return response;
        }

        #endregion

        #region Método Atualizar

        public MovimentacaoResponseDto Atualizar(Guid id, MovimentacaoRequestDto request)
        {
            var movimentacao = _movimentacaoRepository.ObterPorId(id);
            if (movimentacao == null)
                throw new ApplicationException("Movimentação não encontrada");

            _mapper.Map(request, movimentacao);
            _movimentacaoRepository.Update(movimentacao);

            var tarifa = _tarifaRepository.ObterPorEstacionamentoETipo(movimentacao.EstacionamentoId, movimentacao.Veiculo.TipoVeiculo);

            if (tarifa == null)
                throw new ApplicationException("Tarifa não encontrada para o estacionamento e tipo de veículo informados");

            movimentacao.ValorCobrado = CalcularValorCobrado(request.HoraEntrada, request.HoraSaida, tarifa.ValorHora, tarifa.ValorFracao, tarifa.ToleranciaMinutos);

            _mapper.Map(request, movimentacao);
            _movimentacaoRepository.Update(movimentacao);

            var response = _mapper.Map<MovimentacaoResponseDto>(movimentacao);
            return response;
        }

        #endregion

        #region Método Excluir

        public MovimentacaoResponseDto Excluir(Guid id)
        {
            var movimentacao = _movimentacaoRepository.ObterPorId(id);
            if (movimentacao == null)
            {
                throw new ApplicationException("Movimentação não encontrada");
            }

            _movimentacaoRepository.Delete(movimentacao);

            var response = _mapper.Map<MovimentacaoResponseDto>(movimentacao);
            return response;
        }

        #endregion

        #region Método Obter Movimentos em Aberto

        public List<MovimentacaoResponseDto> ObterEmAberto()
        {
            var movimentacao = _movimentacaoRepository.ObterEmAberto();
            if (movimentacao == null || !movimentacao.Any())
            {
                throw new ApplicationException("Nenhuma movimentação em aberto encontrada");
            }

            var response = _mapper.Map<List<MovimentacaoResponseDto>>(movimentacao);
            return response;
        }

        #endregion

        #region Método Obter Histórico por Datas

        public List<MovimentacaoResponseDto> ObterHistoricoPorDatas(DateTime dataInicio, DateTime dataFim)
        {
            var movimentacoes = _movimentacaoRepository.ObterHistoricoPorDatas(dataInicio, dataFim);           
            if (movimentacoes == null || !movimentacoes.Any())
            {
                throw new ApplicationException("Nenhuma movimentação encontrada para o período informado");
            }

            var response = _mapper.Map<List<MovimentacaoResponseDto>>(movimentacoes);
            return response;

        }

        #endregion

        #region Método Obter Histórico Por Placa

        public List<MovimentacaoResponseDto> ObterHistoricoPorPlaca(string placa)
        {
            var movimentacoes = _movimentacaoRepository.ObterHistoricoPorPlaca(placa);
            if (movimentacoes == null || !movimentacoes.Any())
            {
                throw new ApplicationException("Nenhuma movimentação encontrada para a placa informada");
            }

            var response = _mapper.Map<List<MovimentacaoResponseDto>>(movimentacoes);
            return response;
        }

        #endregion

        #region Método Obter por Estacionamento

        public List<MovimentacaoResponseDto> ObterPorEstacionamento(Guid estacionamentoId)
        {
            var movimentacoes = _movimentacaoRepository.ObterPorEstacionamento(estacionamentoId);
            if (movimentacoes == null || !movimentacoes.Any())
            {
                throw new ApplicationException("Nenhuma movimentação encontrada para o estacionamento informado");
            }

            var response = _mapper.Map<List<MovimentacaoResponseDto>>(movimentacoes);
            return response;
        }

        #endregion

        #region Método Obter por ID

        public MovimentacaoResponseDto ObterPorId(Guid id)
        {
            var movimentacao = _movimentacaoRepository.ObterPorId(id);
            if (movimentacao == null)
            {
                throw new ApplicationException("Movimentação não encontrada");
            }

            var response = _mapper.Map<MovimentacaoResponseDto>(movimentacao);
            return response;
        }

        #endregion

        #region Método Obter por Vaga

        public List<MovimentacaoResponseDto> ObterPorVaga(Guid vagaId)
        {
            var movimentacoes = _movimentacaoRepository.ObterPorVaga(vagaId);
            if (movimentacoes == null || !movimentacoes.Any())
            {
                throw new ApplicationException("Nenhuma movimentação encontrada para a vaga informada");
            }

            var response = _mapper.Map<List<MovimentacaoResponseDto>>(movimentacoes);
            return response;
        }

        #endregion

        #region Método Obter por Veículo

        public List<MovimentacaoResponseDto> ObterPorVeiculo(Guid veiculoId)
        {
            var movimentacoes = _movimentacaoRepository.ObterPorVeiculo(veiculoId);
            if (movimentacoes == null || !movimentacoes.Any())
            {
                throw new ApplicationException("Nenhuma movimentação encontrada para o veículo informado");
            }

            var response = _mapper.Map<List<MovimentacaoResponseDto>>(movimentacoes);
            return response;
        }

        #endregion

        #region Método Obter Todos

        public List<MovimentacaoResponseDto> ObterTodos()
        {
            var movimentacoes = _movimentacaoRepository.GetAll();
            var response = _mapper.Map<List<MovimentacaoResponseDto>>(movimentacoes);
            return response;

        }

        #endregion

        #region Método Privado

        private decimal? CalcularValorCobrado(DateTime? horaEntrada, DateTime? horaSaida, decimal? valorHora, decimal? valorFracao, int? toleranciaMinutos)
        {
            TimeSpan? diferenca = horaSaida - horaEntrada;
            var minutosTotais = diferenca?.TotalMinutes ?? 0;

            if (minutosTotais <= toleranciaMinutos)
                return 0;

            var horasCompletas = (int)(minutosTotais / 60);
            var minutosRestantes = minutosTotais % 60;
            var blocosFracao = (int)Math.Round(minutosRestantes / 15);

            if (blocosFracao < 1)
                blocosFracao = 0;

            var total = (horasCompletas * valorHora) + (blocosFracao * valorFracao);

            return total;
        }

        #endregion
    }
}
