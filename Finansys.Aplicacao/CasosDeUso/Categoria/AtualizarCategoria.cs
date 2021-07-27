using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Finansys.Aplicacao.Interfaces;
using Finansys.Aplicacao.Reponses;
using Finansys.Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Finansys.Aplicacao.CasosDeUso
{
    public class AtualizarCategoriaRequest : IRequest<GenericResponse>
    {
        [Required]
        public string Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }


        public string UsuarioId { get; set; }
    }

    public class AtualizarCategoriaRequestHandler : IRequestHandler<AtualizarCategoriaRequest, GenericResponse>
    {

        private ICategoriaRepositorio _categoriaRepositorio { get; set; }

        private ILogger<AtualizarCategoriaRequestHandler> Logger { get; set; }

        public AtualizarCategoriaRequestHandler(ICategoriaRepositorio categoriaRepositorio, ILogger<AtualizarCategoriaRequestHandler> logger)
        {
            _categoriaRepositorio = categoriaRepositorio;
            Logger = logger;
        }

        public async Task<GenericResponse> Handle(AtualizarCategoriaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation("Iniciando Atualização de Categoria");
                //Logger.LogInformation("Consultando Categoria de ID " + request.Id);
                Categoria cat = await _categoriaRepositorio.Consultar(request.UsuarioId, request.Id);

                if (cat == null)
                {
                    Logger.LogWarning("Categoria não encontrada: " + request.Id);
                    return GenericResponse.Error("Categoria não localizada.");
                }

                //Logger.LogInformation("Alterando categoria");
                cat.AlterarCategoria(request.Nome, request.Descricao);

                //Logger.LogInformation("Salvando categoria no banco de dados");
                await _categoriaRepositorio.Atualizar(cat);
                //Logger.LogInformation("Categoria Salva");
                return GenericResponse.Ok("A categoria foi Atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao alterar a categoria");
                return GenericResponse.Error(ex.Message);
            }


        }
    }

}
