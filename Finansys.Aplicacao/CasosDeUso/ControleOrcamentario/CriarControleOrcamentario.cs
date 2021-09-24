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
    public class CriarControleOrcamentarioRequest : IRequest<GenericResponse>
    {
        
        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public string MesReferencia { get; set; }

        public double Valor { get; set; }


        public string UsuarioId { get; set; }
    }

    public class CriarControleOrcamentarioRequestHandler : IRequestHandler<CriarControleOrcamentarioRequest, GenericResponse>
    {

        public IControleOrcamentario ControleOrcamentario { get; set; }

        public CriarControleOrcamentarioRequestHandler(IControleOrcamentario controleOrcamentario)
        {
            ControleOrcamentario = controleOrcamentario;
        }

        public async Task<GenericResponse> Handle(CriarControleOrcamentarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var ControleOrcamento = new ControleOrcamentario(request.Inicio, request.Fim, request.MesReferencia, request.Valor, request.UsuarioId);
                await ControleOrcamentario.NovoOrcamento(ControleOrcamento);
                return GenericResponse.Ok(ControleOrcamento);
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }
}
