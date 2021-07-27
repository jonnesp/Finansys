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
    public class ConsultarLancamentoRequest : IRequest<GenericResponse>
    {
        [Required]
        public string id { get; set; }



        public string UsuarioId { get; set; }
    }

    public class ConsultarLancamentoRequestHandler : IRequestHandler<ConsultarLancamentoRequest, GenericResponse>
    {

        public ILancamentoRepositorio _repo { get; set; }

        public ConsultarLancamentoRequestHandler(ILancamentoRepositorio lancamento)
        {
            _repo = lancamento;
        }

        public async Task<GenericResponse> Handle(ConsultarLancamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var lancamento = await _repo.Consultar(request.id, request.UsuarioId);
                return GenericResponse.Ok(lancamento);
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }
}
