using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Finansys.Aplicacao.Interfaces;
using Finansys.Aplicacao.Reponses;
using Finansys.Dominio.Entidades;
using Finansys.Dominio.Enums;
using MediatR;

namespace Finansys.Aplicacao.CasosDeUso
{
    public class AtualizarLancamentoRequest : IRequest<GenericResponse>
    {
        //string nome, Categoria cat, DateTime data, string descricao, TipoLancamento tipo, double valor

        [Required]
        public string Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        [MaxLength(50)]
        public string CategoriaId { get; set; }

        public DateTime Data { get; set; }
        public TipoLancamento Tipo { get; set; }

        public double Valor { get; set; }

        public string UsuarioId { get; set; }
    }

    public class AtualizarLancamentoRequestHandler : IRequestHandler<AtualizarLancamentoRequest, GenericResponse>
    {

        private ILancamentoRepositorio _lancamentoRepo { get; set; }

        public AtualizarLancamentoRequestHandler(ILancamentoRepositorio lancamento)
        {
            _lancamentoRepo = lancamento;
        }

        public async Task<GenericResponse> Handle(AtualizarLancamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var lancamento = await _lancamentoRepo.Consultar(request.Id, request.UsuarioId);

                if (lancamento == null)
                {
                    return GenericResponse.Error("Lançamento não localizado.");
                }

                lancamento.AlterarDados(request.Nome, request.CategoriaId,request.Data, request.Descricao, request.Tipo, request.Valor);
                await _lancamentoRepo.Atualizar(lancamento);
                return GenericResponse.Ok("O lançamento foi atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }
        }
    }

}
