using Eparking.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Eparking.Domain.Models.DTOs.Request
{
    public class VeiculoRequestDto
    {
        [Required(ErrorMessage = "O tipo de veículo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O modelo deve ter no mínimo {1} caracteres.")]
        public string? Modelo { get; set; }

        [Required(ErrorMessage = "O tipo de veículo é obrigatório.")]
        [MaxLength(7, ErrorMessage = "A placa deve ter no mínimo {1} caracteres.")]
        public string? Placa { get; set; }

        [Required(ErrorMessage = "O tipo de veículo é obrigatório.")]
        [MaxLength(50, ErrorMessage = "A cor deve ter no mínimo {1} caracteres.")]
        public string? Cor { get; set; }

        [Required(ErrorMessage = "O tipo de veículo é obrigatório.")]
        [EnumDataType(typeof(TipoVaga), ErrorMessage = "O campo {0} deve ser um valor válido.")]
        public TipoVeiculo? TipoVeiculo { get; set; }
    }
}
