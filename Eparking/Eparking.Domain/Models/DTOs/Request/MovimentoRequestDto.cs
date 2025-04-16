using System.ComponentModel.DataAnnotations;

namespace Eparking.Domain.Models.DTOs.Request
{
    public class MovimentoRequestDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid EstacionamentoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid VagaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid VeiculoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime? HoraEntrada { get; set; }
    }
}
