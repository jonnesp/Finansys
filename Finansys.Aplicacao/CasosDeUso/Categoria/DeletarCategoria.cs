using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Finansys.Aplicacao.Interfaces;
using Finansys.Aplicacao.Reponses;
using Finansys.Dominio.Entidades;
using MediatR;

namespace Finansys.Aplicacao.CasosDeUso
{
    public class DeletarCategoriaRequest : IRequest<GenericResponse>
    {
        [Required]
        public string Id { get; set; }



        public string UsuarioId { get; set; }
    }

    public class DeletarCategoriaRequestHandler : IRequestHandler<DeletarCategoriaRequest, GenericResponse>
    {

        public ICategoriaRepositorio CategoriaRepositorio { get; set; }

        public DeletarCategoriaRequestHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            CategoriaRepositorio = categoriaRepositorio;
        }

        public async Task<GenericResponse> Handle(DeletarCategoriaRequest request, CancellationToken cancellationToken)
        {
            try
            {

                if (await CategoriaRepositorio.Apagar(request.UsuarioId, request.Id))
                {
                    return GenericResponse.Ok("A categoria foi apagada com sucesso.");
                }
                else
                {
                    return GenericResponse.Error("Categoria não localizada.");
                }
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }

}
