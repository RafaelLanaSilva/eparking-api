using AutoMapper;
using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eparking.Domain.Services
{
    public class VagaDomainService : IVagaService
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IMapper _mapper;

        public VagaDomainService(IVagaRepository vagaRepository, IEstacionamentoRepository estacionamentoRepository, IMapper mapper)
        {
            _vagaRepository = vagaRepository;
            _estacionamentoRepository = estacionamentoRepository;
            _mapper = mapper;
        }
        public VagaResponseDto Criar(VagaRequestDto request)
        {
            var vaga = _mapper.Map<Vaga>(request);
            vaga.Id = Guid.NewGuid();
            var estacionamento = _estacionamentoRepository.ObterPorId(request.EstacionamentoId);
            if (estacionamento == null)
            {
                throw new ApplicationException("Estacionamento não encontrado.");
            }
            vaga.EstacionamentoId = estacionamento.Id;
            _vagaRepository.Add(vaga);

            var response = _mapper.Map<VagaResponseDto>(vaga);
            return response;
        }

        public VagaResponseDto Atualizar(Guid id, VagaRequestDto request)
        {
            var vaga = _vagaRepository.ObterVagaPorId(id);
            if (vaga == null)
            {
                throw new ApplicationException("Vaga não encontrada.");
            }

            var estacionamento = _estacionamentoRepository.ObterPorId(request.EstacionamentoId);
            if (estacionamento == null)
            {
                throw new ApplicationException("Estacionamento não encontrado.");
            }

            _mapper.Map(request, vaga);
            _vagaRepository.Update(vaga);

            var response = _mapper.Map<VagaResponseDto>(vaga);
            return response;
        }

        public VagaResponseDto Excluir(Guid id)
        {
            var vaga = _vagaRepository.ObterVagaPorId(id);
            if (vaga == null)
            {
                throw new ApplicationException("Vaga não encontrada.");
            }

            _vagaRepository.Delete(vaga);

            var response = _mapper.Map<VagaResponseDto>(vaga);
            return response;

        }

        public List<VagaResponseDto> ObterDisponiveisPorEstacionamento(Guid estacionamentoId)
        {
            var vagas = _vagaRepository.ObterVagasDisponiveis(estacionamentoId);
            if (vagas == null || !vagas.Any())
            {
                throw new ApplicationException("Nenhuma vaga disponível encontrada.");
            }

            var response = _mapper.Map<List<VagaResponseDto>>(vagas);
            return response;
        }

        public List<VagaResponseDto> ObterOcupadasPorEstacionamento(Guid estacionamentoId)
        {
            var vagas = _vagaRepository.ObterVagasOcupadas(estacionamentoId);
            if (vagas == null || !vagas.Any())
            {
                throw new ApplicationException("Nenhuma vaga ocupada encontrada.");
            }

            var response = _mapper.Map<List<VagaResponseDto>>(vagas);
            return response;
        }

        public List<VagaResponseDto> ObterPorEstacionamento(Guid estacionamentoId)
        {
            var vagas = _vagaRepository.ObterVagasDisponiveis(estacionamentoId);
            if (vagas == null || !vagas.Any())
            {
                throw new ApplicationException("Nenhuma vaga encontrada no estacionamento informado.");
            }

            var response = _mapper.Map<List<VagaResponseDto>>(vagas);
            return response;
        }

        public VagaResponseDto? ObterPorId(Guid id)
        {
            var vagas = _vagaRepository.ObterVagaPorId(id);
            if (vagas == null)
            {
                throw new ApplicationException("Vaga não encontrada.");
            }

            var response = _mapper.Map<VagaResponseDto>(vagas);
            return response;
        }

        public List<VagaResponseDto> ObterPorTipo(TipoVaga tipoVaga)
        {
            var vagas = _vagaRepository.ObterVagasPorTipo(tipoVaga);
            if (vagas == null || !vagas.Any())
            {
                throw new ApplicationException("Nenhuma vaga encontrada do tipo informado.");
            }

            var response = _mapper.Map<List<VagaResponseDto>>(vagas);
            return response;
        }
    }
}
