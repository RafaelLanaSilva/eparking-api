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
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IVagaRepository _vagaRepository;
        private readonly IMapper _mapper;

        public MovimentacaoDomainService(IMovimentacaoRepository movimentacaoRepository, IEstacionamentoRepository estacionamentoRepository, IVagaRepository vagaRepository, IMapper mapper)
        {
            _movimentacaoRepository = movimentacaoRepository;
            _estacionamentoRepository = estacionamentoRepository;
            _vagaRepository = vagaRepository;
            _mapper = mapper;
        }

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

        public MovimentacaoResponseDto Atualizar(Guid id, MovimentacaoRequestDto request)
        {
            var movimentacao = _movimentacaoRepository.ObterPorId(id);
            if (movimentacao == null)
            {
                throw new ApplicationException("Movimentação não encontrada");
            }
            _mapper.Map(request, movimentacao);
            _movimentacaoRepository.Update(movimentacao);

            var response = _mapper.Map<MovimentacaoResponseDto>(movimentacao);
            return response;
        }

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

        public List<MovimentacaoResponseDto> ObterTodos()
        {
            var movimentacoes = _movimentacaoRepository.GetAll();
            var response = _mapper.Map<List<MovimentacaoResponseDto>>(movimentacoes);
            return response;

        }
    }
}
