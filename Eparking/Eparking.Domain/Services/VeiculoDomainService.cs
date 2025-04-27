using AutoMapper;
using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Entities;
using Eparking.Domain.Models.Enums;

namespace Eparking.Domain.Services
{
    public class VeiculoDomainService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculoDomainService(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public VeiculoResponseDto Criar(VeiculoRequestDto request)
        {
            if (_veiculoRepository.ObterPorPlaca(request.Placa!) != null)
                throw new ApplicationException("Já existe um veículo cadastrado com essa placa.");

            var veiculo = _mapper.Map<Veiculo>(request);           
            veiculo.Id = Guid.NewGuid();
            
            _veiculoRepository.Add(veiculo);

            var response = _mapper.Map<VeiculoResponseDto>(veiculo);
            return response;
        }

        public VeiculoResponseDto Atualizar(Guid id, VeiculoRequestDto request)
        {
            var veiculo = _veiculoRepository.ObterPorId(id);
            if (veiculo == null)
            {
                throw new Exception("Veículo não encontrado.");
            }

            _mapper.Map(request, veiculo);
            _veiculoRepository.Update(veiculo);

            var response = _mapper.Map<VeiculoResponseDto>(veiculo);
            return response;
        }

        public VeiculoResponseDto Excluir(Guid id)
        {
            var veiculo = _veiculoRepository.ObterPorId(id);
            if (veiculo == null)
            {
                throw new Exception("Veículo não encontrado.");
            }
            _veiculoRepository.Delete(veiculo);

            var response = _mapper.Map<VeiculoResponseDto>(veiculo);
            return response;
        }

        public VeiculoResponseDto? ObterPorId(Guid id)
        {
            var veiculo = _veiculoRepository.ObterPorId(id);
            if ( veiculo == null)
            {
                throw new ApplicationException("Veiculo não encontrado.");
            }

            var response = _mapper.Map<VeiculoResponseDto>(veiculo);
            return response;
        }

        public List<VeiculoResponseDto> ObterTodos()
        {
            var veiculos = _veiculoRepository.GetAll();
            var response = _mapper.Map<List<VeiculoResponseDto>>(veiculos);
            return response;
        }

        public VeiculoResponseDto? ObterPorPlaca(string placa)
        {
            var veiculo = _veiculoRepository.ObterPorPlaca(placa);
            if (veiculo == null)
            {
                throw new ApplicationException("Veiculo não encontrado. Verifique a placa informada.");
            }

            var response = _mapper.Map<VeiculoResponseDto>(veiculo);
            return response;
        }

        public List<VeiculoResponseDto> ObterPorTipo(TipoVeiculo tipoVeiculo)
        {
            var veiculos = _veiculoRepository.ObterVeiculosPorTipo(tipoVeiculo);
            var response = _mapper.Map<List<VeiculoResponseDto>>(veiculos);
            return response;
        }

        public List<VeiculoResponseDto> ObterComMovimentacoes()
        {
            var veiculo = _veiculoRepository.ObterVeiculosComMovimentacoes();
            var response = _mapper.Map<List<VeiculoResponseDto>>(veiculo);
            return response;
        }
    }
}
