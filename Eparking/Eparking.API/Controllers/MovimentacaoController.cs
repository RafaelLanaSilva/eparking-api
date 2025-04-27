using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Models.DTOs.Request;
using Eparking.Domain.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Eparking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacaoController(IMovimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 201)]

        public IActionResult Post(MovimentacaoRequestDto request)
        {
            try
            {
                var response = _movimentacaoService.Criar(request);

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
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 200)]
        public IActionResult Put(Guid id, MovimentacaoRequestDto request)
        {
            try
            {
                var response = _movimentacaoService.Atualizar(id, request);

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
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _movimentacaoService.Excluir(id);

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
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _movimentacaoService.ObterTodos();
                
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
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var result = _movimentacaoService.ObterPorId(id);

                return StatusCode(200, result);
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


        [HttpGet("{placa}")]
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 200)]
        public IActionResult GetByPlaca(string placa)
        {
            try
            {
                var response = _movimentacaoService.ObterHistoricoPorPlaca(placa);
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
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 200)]
        public IActionResult GetByEstacionamento(Guid estacionamentoId)
        {
            try
            {
                var response = _movimentacaoService.ObterPorEstacionamento(estacionamentoId);
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

        [HttpGet("{vagaId}")]
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 200)]
        public IActionResult GetByVaga(Guid vagaId)
        {
            try
            {
                var response = _movimentacaoService.ObterPorVaga(vagaId);
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

        [HttpGet("{veiculoId}")]
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 200)]
        public IActionResult GetByVeiculo(Guid veiculoId)
        {
            try
            {
                var response = _movimentacaoService.ObterPorVeiculo(veiculoId);
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

        [HttpGet("{dataInicio}/{dataFim}")]
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 200)]
        public IActionResult GetByData(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var response = _movimentacaoService.ObterHistoricoPorDatas(dataInicio, dataFim);
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

        [HttpGet("aberto")]
        [ProducesResponseType(typeof(MovimentacaoResponseDto), 200)]
        public IActionResult GetByOpen()
        {
            try
            {
                var response = _movimentacaoService.ObterEmAberto();
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
