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
            CreateMap<Vaga, VagaResponseDto>()
                .ForMember(dest => dest.TipoVaga, opt => opt.MapFrom(src => src.TipoVaga.ToString()));  // Mapeia para o nome do enum;

            CreateMap<EstacionamentoRequestDto, Estacionamento>();
            CreateMap<Estacionamento, EstacionamentoResponseDto>();
            CreateMap<Estacionamento, EstacionamentoComVagasResponseDto>();

            CreateMap<TarifaRequestDto, Tarifa>();
            CreateMap<Tarifa, TarifaResponseDto>();

            CreateMap<MovimentacaoRequestDto, Movimentacao>();
            CreateMap<Movimentacao, MovimentacaoResponseDto>();
        }
    }
}
