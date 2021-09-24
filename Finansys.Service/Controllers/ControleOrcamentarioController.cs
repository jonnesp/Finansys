using Finansys.Aplicacao.CasosDeUso;
using Finansys.Aplicacao.Reponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finansys.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ControleOrcamentarioController : Controller
    {

        private readonly ILogger<ControleOrcamentarioController> _logger;

        private IMediator Mediator;

        public ControleOrcamentarioController(ILogger<ControleOrcamentarioController> logger, IMediator mediator)
        {
            _logger = logger;
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> NovoControleOrcamentario([FromBody] CriarControleOrcamentarioRequest request)
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
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CategoriaOrcamento ([FromBody] CriarCategoriaOrcamentoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
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
    }
}
