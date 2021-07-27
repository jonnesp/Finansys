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
    public class CriarCategoriaRequest : IRequest<GenericResponse>
    {
        [Required(ErrorMessage = "Nome da categoria é obrigatória")]
        public string Nome { get; set; }

        public string Descricao { get; set; }


        public string UsuarioId { get; set; }
    }

    public class CriarCategoriaRequestHandler : IRequestHandler<CriarCategoriaRequest, GenericResponse>
    {

        public ICategoriaRepositorio CategoriaRepositorio { get; set; }

        public CriarCategoriaRequestHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            CategoriaRepositorio = categoriaRepositorio;
        }

        public async Task<GenericResponse> Handle(CriarCategoriaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Categoria categoria = new Categoria(request.Nome, request.Descricao, request.UsuarioId);
                await CategoriaRepositorio.Inserir(categoria);
                return GenericResponse.Ok(categoria);
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }
}
