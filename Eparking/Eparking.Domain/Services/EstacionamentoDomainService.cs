using AutoMapper;
using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Services
{
    public class EstacionamentoDomainService : IEstacionamentoService
    {
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IVagaRepository _vagaRepository;
        private readonly IMapper _mapper;

        public EstacionamentoDomainService(IEstacionamentoRepository estacionamentoRepository, IVagaRepository vagaRepository, IMapper mapper)
        {
            _estacionamentoRepository = estacionamentoRepository;
            _vagaRepository = vagaRepository;
            _mapper = mapper;
        }

        public EstacionamentoResponseDto Criar(EstacionamentoRequestDto request)
        {
            var estacionamento = _mapper.Map<Estacionamento>(request);
            estacionamento.Id = Guid.NewGuid();

            _estacionamentoRepository.Add(estacionamento);

            var vagas = GerarVagas(estacionamento);

            _vagaRepository.AddRange(vagas);

            var response = _mapper.Map<EstacionamentoResponseDto>(estacionamento);
            return response;
        }

        public EstacionamentoResponseDto Atualizar(Guid id, EstacionamentoRequestDto request)
        {
            var estacionamentoExistente = _estacionamentoRepository.ObterPorId(id);
            if (estacionamentoExistente == null )
            {
                throw new ApplicationException("Estacionamento não encontrado.");
            }

            _mapper.Map(request, estacionamentoExistente);
            _estacionamentoRepository.Update(estacionamentoExistente);

            var vagasAtuais = _vagaRepository.ObterPorEstacionamento(estacionamentoExistente.Id);
            if (vagasAtuais != null && vagasAtuais.Any())
            {
                foreach (var vaga in vagasAtuais)
                    _vagaRepository.Delete(vaga);
            }

            var novasVagas = GerarVagas(estacionamentoExistente);
            _vagaRepository.AddRange(novasVagas);

            var response = _mapper.Map<EstacionamentoResponseDto>(estacionamentoExistente);
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

        private List<Vaga> GerarVagas(Estacionamento estacionamento)
        {
            var vagas = new List<Vaga>();

            for (int i = 0; i < estacionamento.QuantidadeVagasCarro; i++)
            {
                vagas.Add(new Vaga
                {
                    Id = Guid.NewGuid(),
                    Numero = i + 1,
                    TipoVaga = TipoVaga.Carro,
                    EstacionamentoId = estacionamento.Id
                });
            }

            for (int i = 0; i < estacionamento.QuantidadeVagasMotocicleta; i++)
            {
                vagas.Add(new Vaga
                {
                    Id = Guid.NewGuid(),
                    Numero = i + 1,
                    TipoVaga = TipoVaga.Motocicleta,
                    EstacionamentoId = estacionamento.Id
                });
            }

            for (int i = 0; i < estacionamento.QuantidadeVagasPreferencial; i++)
            {
                vagas.Add(new Vaga
                {
                    Id = Guid.NewGuid(),
                    Numero = i + 1,
                    TipoVaga = TipoVaga.Preferencial,
                    EstacionamentoId = estacionamento.Id
                });
            }

            return vagas;
        }
    }
}

