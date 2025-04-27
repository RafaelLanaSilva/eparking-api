using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Eparking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionamentoController : ControllerBase
    {
        private readonly IEstacionamentoService _estacionamentoService;

        public EstacionamentoController(IEstacionamentoService estacionamentoService)
        {
            _estacionamentoService = estacionamentoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EstacionamentoResponseDto), 201)]
        public IActionResult Post(EstacionamentoRequestDto request)
        {
            try
            {
                var response = _estacionamentoService.Criar(request);

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
        [ProducesResponseType(typeof(EstacionamentoResponseDto), 200)]
        public IActionResult Put(Guid id, EstacionamentoRequestDto request)
        {
            try
            {
                var response = _estacionamentoService.Atualizar(id, request);

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
        [ProducesResponseType(typeof(EstacionamentoResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _estacionamentoService.Excluir(id);

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

        [HttpGet]
        [ProducesResponseType(typeof(EstacionamentoResponseDto), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _estacionamentoService.ObterTodos();

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
        [ProducesResponseType(typeof(EstacionamentoResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _estacionamentoService.ObterPorId(id);

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

        [HttpGet("{id}/vagas")]
        [ProducesResponseType(typeof(EstacionamentoResponseDto), 200)]
        public IActionResult GetByVaga(Guid id)
        {
            try
            {
                var response = _estacionamentoService.ObterComVagas(id);

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

        [HttpGet("{nome}")]
        [ProducesResponseType(typeof(EstacionamentoResponseDto), 200)]
        public IActionResult GetByNome(string nome)
        {
            try
            {
                var response = _estacionamentoService.ObterPorNome(nome);

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
