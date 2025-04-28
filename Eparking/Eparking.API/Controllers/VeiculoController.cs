using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Eparking.Domain.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Eparking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(VeiculoResponseDto), 201)]
        public IActionResult Post(VeiculoRequestDto request)
        {
            try
            {
                var response = _veiculoService.Criar(request);

                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VeiculoResponseDto), 200)]
        public IActionResult Put(Guid id, VeiculoRequestDto request)
        {
            try
            {
                var response = _veiculoService.Atualizar(id, request);

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
        [ProducesResponseType(typeof(VeiculoResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _veiculoService.Excluir(id);

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
        [ProducesResponseType(typeof(VeiculoResponseDto), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _veiculoService.ObterTodos();

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
        [ProducesResponseType(typeof(VeiculoResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _veiculoService.ObterPorId(id);

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

        [HttpGet("placa/{placa}")]
        [ProducesResponseType(typeof(VeiculoResponseDto), 200)]
        public IActionResult GetByPlaca(string placa)
        {
            try
            {
                var response = _veiculoService.ObterPorPlaca(placa);

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

        [HttpGet("tipo/{tipoVeiculo}")]
        [ProducesResponseType(typeof(VeiculoResponseDto), 200)]
        public IActionResult GetByTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            try
            {
                var response = _veiculoService.ObterPorTipo(tipoVeiculo);
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

        [HttpGet("movimentacoes")]
        [ProducesResponseType(typeof(VeiculoResponseDto), 200)]
        public IActionResult GetByMovements()
        {
            try
            {
                var response = _veiculoService.ObterComMovimentacoes();
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
