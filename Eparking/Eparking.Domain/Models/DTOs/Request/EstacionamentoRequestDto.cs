using System.ComponentModel.DataAnnotations;

namespace Eparking.Domain.Models.DTOs.Request
{
    public class EstacionamentoRequestDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int? QuantidadeVagasCarro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int? QuantidadeVagasMotocicleta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int? QuantidadeVagasPreferencial { get; set; }
    }
}
