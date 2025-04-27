using AutoMapper;
using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Entities;

namespace Eparking.Domain.Services
{
    public class EstacionamentoDomainService : IEstacionamentoService
    {
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IMapper _mapper;

        public EstacionamentoDomainService(IEstacionamentoRepository estacionamentoRepository, IMapper mapper)
        {
            _estacionamentoRepository = estacionamentoRepository;
            _mapper = mapper;
        }

        public EstacionamentoResponseDto Criar(EstacionamentoRequestDto request)
        {
            var estacionamento = _mapper.Map<Estacionamento>(request);
            estacionamento.Id = Guid.NewGuid();

            _estacionamentoRepository.Add(estacionamento);

            var response = _mapper.Map<EstacionamentoResponseDto>(estacionamento);
            return response;
        }

        public EstacionamentoResponseDto Atualizar(Guid id, EstacionamentoRequestDto request)
        {
            var estacionamento = _estacionamentoRepository.ObterPorId(id);
            if ( estacionamento == null )
            {
                throw new ApplicationException("Estacionamento não encontrado.");
            }

            _mapper.Map(request, estacionamento);
            _estacionamentoRepository.Update(estacionamento);

            var response = _mapper.Map<EstacionamentoResponseDto>(estacionamento);
            return response;
        }   

        public EstacionamentoResponseDto Excluir(Guid id)
        {
            var estacionamento = _estacionamentoRepository.ObterPorId(id);
            if (estacionamento == null )    
            {
                throw new ApplicationException("Estacionamento não encontrado.");
            }

            _estacionamentoRepository.Delete(estacionamento);

            var response = _mapper.Map<EstacionamentoResponseDto>(estacionamento);
            return response;
        }

        public List<EstacionamentoResponseDto> ObterTodos()
        {
            var estacionamentos = _estacionamentoRepository.GetAll();
            var response = _mapper.Map<List<EstacionamentoResponseDto>>(estacionamentos);

            return response;
        }

        public EstacionamentoResponseDto? ObterComVagas(Guid id)
        {
            var estacionamento = _estacionamentoRepository.ObterComVagas(id);
            if (estacionamento == null)
            {
                throw new ApplicationException("Estacionamento não encontrado ou sem vagas cadastradas.");
            }

            var response = _mapper.Map<EstacionamentoComVagasResponseDto>(estacionamento);
            return response;
        }

        public EstacionamentoResponseDto ObterPorId(Guid id)
        {
            var estacionamento = _estacionamentoRepository.ObterPorId(id);
            if (estacionamento == null)
            {
                throw new ApplicationException("Estacionamento não encontrado.");
            }

            var response = _mapper.Map<EstacionamentoResponseDto>(estacionamento);
            return response;
        }

        public List<EstacionamentoResponseDto> ObterPorNome(string nome)
        {
            var estacionamentos = _estacionamentoRepository.ObterPorNome(nome);
            if (!estacionamentos.Any())
            {
                throw new ApplicationException("Estacionamento não encontrado.Verifique o nome informado");
            }

            var response = _mapper.Map<List<EstacionamentoResponseDto>>(estacionamentos);
            return response;
        }
    }
}
