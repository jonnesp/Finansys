using MediatR;
using Finansys.Dominio.Entidades;
using Finansys.Aplicacao.Reponses;
using System.Threading.Tasks;
using System.Threading;
using Finansys.Aplicacao.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using Finansys.Dominio.Enums;

namespace Finansys.Aplicacao.CasosDeUso
{
    public class CriarLancamentoRequest : IRequest<GenericResponse>
    {
        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string CategoriaId { get; set; }

        public DateTime Data { get; set; }

        [Required]
        public TipoLancamento Tipo { get; set; }

        [Required]
        public double Valor { get; set; }
        public string UsuarioId { get; set; }

    }

    public class CriarLancamentoRequestHandler : IRequestHandler<CriarLancamentoRequest, GenericResponse>
    {

        public ILancamentoRepositorio _lancamentoRepo { get; set; }
        public ICategoriaRepositorio _categoriaRepo { get; set; }

        public CriarLancamentoRequestHandler(ILancamentoRepositorio lancamentoRepo, ICategoriaRepositorio categoriaRepo)
        {
            _lancamentoRepo = lancamentoRepo;
            _categoriaRepo = categoriaRepo;
        }

        public async Task<GenericResponse> Handle(CriarLancamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await _categoriaRepo.Consultar(request.UsuarioId, request.CategoriaId);
                if (categoria == null)
                {
                    throw new Exception("Categoria não encontrada.");
                }
                
                
                var lancamento = new Lancamento(request.Nome, request.CategoriaId, categoria, request.Data ,request.Descricao, request.Tipo, request.Valor, request.UsuarioId);
                

                await _lancamentoRepo.Inserir(lancamento, request.CategoriaId);

                return GenericResponse.Ok(lancamento);
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }
}
