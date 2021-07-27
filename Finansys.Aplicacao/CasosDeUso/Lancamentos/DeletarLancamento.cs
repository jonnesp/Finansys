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
    public class DeletarLancamentoRequest : IRequest<GenericResponse>
    {
        [Required]
        public string Id { get; set; }



        public string UsuarioId { get; set; }
    }

    public class DeletarLancamentoRequestHandler : IRequestHandler<DeletarLancamentoRequest, GenericResponse>
    {

        public ILancamentoRepositorio _repo { get; set; }

        public DeletarLancamentoRequestHandler(ILancamentoRepositorio lancamentoRepo)
        {
            _repo = lancamentoRepo;
        }

        public async Task<GenericResponse> Handle(DeletarLancamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {

                await _repo.Apagar(request.Id, request.UsuarioId);
                return GenericResponse.Ok("O lancamento foi apagado com sucesso.");
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }

}
