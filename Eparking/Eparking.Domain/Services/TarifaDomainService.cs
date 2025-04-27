using AutoMapper;
using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Services
{
    public class TarifaDomainService : ITarifaService
    {
        private readonly ITarifaRepository _tarifaRepository;
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IMapper _mapper;

        public TarifaDomainService(ITarifaRepository tarifaRepository, IEstacionamentoRepository estacionamentoRepository, IMapper mapper)
        {
            _tarifaRepository = tarifaRepository;
            _estacionamentoRepository = estacionamentoRepository;
            _mapper = mapper;
        }
        public TarifaResponseDto Criar(TarifaRequestDto request)
        {
            var estacionamento = _estacionamentoRepository.ObterPorId(request.EstacionamentoId);
            if (estacionamento == null)
            {
                throw new ApplicationException("Estacionamento não encontrado.");
            }

            var tarifaExistente = _tarifaRepository.ObterPorEstacionamentoETipo(request.EstacionamentoId, request.TipoVeiculo.Value);
            if (tarifaExistente != null)
            {
                throw new ApplicationException("Já existe uma tarifa cadastrada para este tipo de veículo neste estacionamento.");
            }

            var tarifa = _mapper.Map<Tarifa>(request);
            tarifa.Id = Guid.NewGuid();

            _tarifaRepository.Add(tarifa);

            var response = _mapper.Map<TarifaResponseDto>(tarifa);
            return response;
        }

        public TarifaResponseDto Atualizar(Guid id, TarifaRequestDto request)
        {
            var tarifa= _tarifaRepository.ObterTarifaPorId(id);
            if (tarifa == null)
            {
                throw new ApplicationException("Tarifa não encontrada.");
            }
            var estacionamento = _estacionamentoRepository.ObterPorId(request.EstacionamentoId);
            if (estacionamento == null)
            {
                throw new ApplicationException("Estacionamento não encontrado.");
            }

            _mapper.Map(request, tarifa);
            _tarifaRepository.Update(tarifa);

            var response = _mapper.Map<TarifaResponseDto>(tarifa);
            return response;
        }

        public TarifaResponseDto Excluir(Guid id)
        {
            var tarifa = _tarifaRepository.ObterTarifaPorId(id);
            if (tarifa == null)
            {
                throw new ApplicationException("Tarifa não encontrada.");
            }

            _tarifaRepository.Delete(tarifa);

            var response = _mapper.Map<TarifaResponseDto>(tarifa);
            return response;

        }

        public List<TarifaResponseDto> ObterPorEstacionamento(Guid estacionamentoId)
        {
            var tarifas = _tarifaRepository.ObterPorEstacionamentoId(estacionamentoId);
            if (tarifas == null || !tarifas.Any())
            {
                throw new ApplicationException("Nenhuma tarifa encontrada para o estacionamento informado.");
            }

            var response = _mapper.Map<List<TarifaResponseDto>>(tarifas);
            return response;
        }

        public TarifaResponseDto? ObterPorId(Guid id)
        {
            var tarifa = _tarifaRepository.ObterTarifaPorId(id);
            if (tarifa == null)
            {
                throw new ApplicationException("Tarifa não encontrada.");
            }

            var response = _mapper.Map<TarifaResponseDto>(tarifa);
            return response;
        }

        public List<TarifaResponseDto> ObterPorTipoVeiculo(Guid estacionamentoId, TipoVeiculo tipoVeiculo)
        {
            var tarifas = _tarifaRepository.ObterPorTipoVeiculo(estacionamentoId, tipoVeiculo);
            if (tarifas == null)
            {
                throw new ApplicationException("Nenhuma tarifa encontrada para o tipo de veículo informado.");
            }

            var response = _mapper.Map<List<TarifaResponseDto>>(tarifas);
            return response;
        }

        public List<TarifaResponseDto> ObterTodos()
        {
            var tarifa = _tarifaRepository.GetAll();
            if (tarifa == null)
            {
                throw new ApplicationException("Nenhuma tarifa encontrada.");
            }

            var response = _mapper.Map<List<TarifaResponseDto>>(tarifa);
            return response;
        }
    }
}
