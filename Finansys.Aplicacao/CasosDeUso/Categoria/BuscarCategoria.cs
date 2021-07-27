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
    public class BuscarCategoriaRequest : IRequest<GenericResponse>
    {

        public string UsuarioId { get; set; }

    }

    public class BuscarCategoriaRequestHandler : IRequestHandler<BuscarCategoriaRequest, GenericResponse>
    {

        public ICategoriaRepositorio CategoriaRepositorio { get; set; }

        public BuscarCategoriaRequestHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            CategoriaRepositorio = categoriaRepositorio;
        }

        public async Task<GenericResponse> Handle(BuscarCategoriaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var listaDeCategorias = await CategoriaRepositorio.Buscar(request.UsuarioId);
                return GenericResponse.Ok(listaDeCategorias);
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }
}
