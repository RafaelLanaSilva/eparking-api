using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Eparking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifaController : ControllerBase
    {
        private readonly ITarifaService _tarifaService;

        public TarifaController(ITarifaService tarifaService)
        {
            _tarifaService = tarifaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TarifaResponseDto), 201)]
        public IActionResult Post(TarifaRequestDto request)
        {
            try
            {
                var response = _tarifaService.Criar(request);

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
        [ProducesResponseType(typeof(TarifaResponseDto), 200)]
        public IActionResult Put(Guid id, TarifaRequestDto request)
        {
            try
            {
                var response = _tarifaService.Atualizar(id, request);

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
        [ProducesResponseType(typeof(TarifaResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _tarifaService.Excluir(id);

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
        [ProducesResponseType(typeof(IEnumerable<TarifaResponseDto>), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _tarifaService.ObterTodos();

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
        [ProducesResponseType(typeof(TarifaResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _tarifaService.ObterPorId(id);

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

        [HttpGet("estacionamento/{estacionamentoId}")]
        [ProducesResponseType(typeof(TarifaResponseDto), 200)]
        public IActionResult GetByEstacionamento(Guid estacionamentoId)
        {
            try
            {
                var response = _tarifaService.ObterPorEstacionamento(estacionamentoId);
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

        [HttpGet("estacionamento{estacionamentoId}/tipo/{tipoVeiculo}")]
        [ProducesResponseType(typeof(TarifaResponseDto), 200)]
        public IActionResult GetByTipoVeiculo(Guid estacionamentoId, TipoVeiculo tipoVeiculo)
        {
            try
            {
                var response = _tarifaService.ObterPorTipoVeiculo(estacionamentoId, tipoVeiculo);
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
