using AutoMapper;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Entities;

namespace Eparking.Domain.Mappings
{
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            CreateMap<VeiculoRequestDto, Veiculo>();
            CreateMap<Veiculo, VeiculoResponseDto>();

            CreateMap<VagaRequestDto, Vaga>();
            CreateMap<Vaga, VagaResponseDto>();

            CreateMap<EstacionamentoRequestDto, Estacionamento>();
            CreateMap<Estacionamento, EstacionamentoResponseDto>();

            CreateMap<TarifaRequestDto, Tarifa>();
            CreateMap<Tarifa, TarifaResponseDto>();

            CreateMap<MovimentacaoRequestDto, Movimentacao>();
            CreateMap<Movimentacao, MovimentacaoResponseDto>();
        }
    }
}
