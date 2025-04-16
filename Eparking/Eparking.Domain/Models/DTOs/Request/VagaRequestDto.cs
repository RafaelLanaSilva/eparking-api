using Eparking.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Eparking.Domain.Models.DTOs.Request
{
    public class VagaRequestDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int? Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EnumDataType(typeof(TipoVaga), ErrorMessage = "O campo {0} deve ser um valor válido.")]
        public TipoVaga? TipoVaga { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Ocupado { get; set; } = false;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid EstacionamentoId { get; set; }

    }
}
