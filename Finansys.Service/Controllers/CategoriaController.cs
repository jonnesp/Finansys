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
    public class CategoriaController : ControllerBase
    {


        private readonly ILogger<CategoriaController> _logger;

        private IMediator Mediator;

        public CategoriaController(ILogger<CategoriaController> logger, IMediator mediator)
        {
            _logger = logger;
            Mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarCategoriaRequest request)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    _logger.LogError("Requisição chegou em estado inválido.");
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Coletando id do usuário autenticado.");
                request.UsuarioId = User.GetuserName();

                _logger.LogInformation("Enviando request para tratativas do mediator.");
                GenericResponse response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneCategory([FromRoute] ConsultarCategoriaRequest request)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }
                request.UsuarioId = User.GetuserName();
                GenericResponse response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorys([FromQuery] BuscarCategoriaRequest request)
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
        public async Task<IActionResult> Put([FromBody] AtualizarCategoriaRequest request)
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
        public async Task<IActionResult> Delete([FromRoute] DeletarCategoriaRequest request)
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
