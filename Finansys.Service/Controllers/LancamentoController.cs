using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using Finansys.Aplicacao.CasosDeUso;
using Finansys.Aplicacao.Reponses;
using Microsoft.AspNetCore.Authorization;

namespace Finansys.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LancamentoController : ControllerBase
    {


        private readonly ILogger<LancamentoController> _logger;

        private IMediator Mediator;

        public LancamentoController(ILogger<LancamentoController> logger, IMediator mediator)
        {
            _logger = logger;
            Mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarLancamentoRequest request)
        {
            try
            {
                request.UsuarioId = User.GetuserName();
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }
                GenericResponse response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneCategory([FromRoute] ConsultarLancamentoRequest request)
        {
            try
            {
                request.UsuarioId = User.GetuserName();
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }

                GenericResponse response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorys([FromQuery] BuscarLancamentoRequest request)
        {
            try
            {
                request.UsuarioId = User.GetuserName();
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }
                GenericResponse response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AtualizarLancamentoRequest request)
        {
            try
            {
                request.UsuarioId = User.GetuserName();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                GenericResponse response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeletarLancamentoRequest request)
        {
            try
            {
                request.UsuarioId = User.GetuserName();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                GenericResponse response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
