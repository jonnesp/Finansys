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
    public class BuscarLancamentoRequest : IRequest<GenericResponse>
    {

        public string UsuarioId { get; set; }
    }

    public class BuscarLancamentoRequestHandler : IRequestHandler<BuscarLancamentoRequest, GenericResponse>
    {

        public ILancamentoRepositorio _repo { get; set; }

        public BuscarLancamentoRequestHandler(ILancamentoRepositorio lancamento)
        {
            _repo = lancamento;
        }

        public async Task<GenericResponse> Handle(BuscarLancamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var lancamento = await _repo.Buscar(request.UsuarioId);
                return GenericResponse.Ok(lancamento);
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }
}
