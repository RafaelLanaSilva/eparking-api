using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Eparking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagaController : ControllerBase
    {
        private readonly IVagaService _vagaService;

        public VagaController(IVagaService vagaService)
        {
            _vagaService = vagaService;;
        }

        [HttpPost]
        [ProducesResponseType(typeof(VagaResponseDto), 201)]
        public IActionResult Post(VagaRequestDto request)
        {
            try
            {
                var response = _vagaService.Criar(request);

                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VagaResponseDto), 200)]
        public IActionResult Put(Guid id, VagaRequestDto requestDto)
        {
            try
            {
                var response = _vagaService.Atualizar(id, requestDto);

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(VagaResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _vagaService.Excluir(id);

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VagaResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok();
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{estacionamentoId}/disponiveis")]
        [ProducesResponseType(typeof(VagaResponseDto), 200)]
        public IActionResult GetByAvailability(Guid estacionamentoId)
        {
            try
            {
                var response = _vagaService.ObterDisponiveisPorEstacionamento(estacionamentoId);

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{estacionamentoId}/ocupados")]
        [ProducesResponseType(typeof(VagaResponseDto), 200)]
        public IActionResult GetByBusy(Guid estacionamentoId)
        {
            try
            {
                var response = _vagaService.ObterOcupadasPorEstacionamento(estacionamentoId);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{tipoVaga}")]
        [ProducesResponseType(typeof(VagaResponseDto), 200)]
        public IActionResult GetByType(TipoVaga tipoVaga)
        {
            try
            {
                var response = _vagaService.ObterPorTipo(tipoVaga);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{estacionamentoId}")]
        [ProducesResponseType(typeof(VagaResponseDto), 200)]
        public IActionResult GetByParking(Guid estacionamentoId)
        {
            try
            {
                var response = _vagaService.ObterPorEstacionamento(estacionamentoId);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
