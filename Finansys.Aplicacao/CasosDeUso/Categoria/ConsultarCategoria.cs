using MediatR;
using Finansys.Dominio.Entidades;
using Finansys.Aplicacao.Reponses;
using System.Threading.Tasks;
using System.Threading;
using Finansys.Aplicacao.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Finansys.Aplicacao.CasosDeUso
{
    public class ConsultarCategoriaRequest : IRequest<GenericResponse>
    {
        [Required]
        public string id { get; set; }


        public string UsuarioId { get; set; }
    }

    public class ConsultarCategoriaRequestHandler : IRequestHandler<ConsultarCategoriaRequest, GenericResponse>
    {

        public ICategoriaRepositorio CategoriaRepositorio { get; set; }

        public ConsultarCategoriaRequestHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            CategoriaRepositorio = categoriaRepositorio;
        }

        public async Task<GenericResponse> Handle(ConsultarCategoriaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await CategoriaRepositorio.Consultar(request.UsuarioId, request.id);
                return GenericResponse.Ok(categoria);
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }
}
