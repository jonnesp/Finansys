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

        public string ControleOrcamentarioId { get; set;}
        public string UsuarioId { get; set; }

    }

    public class CriarLancamentoRequestHandler : IRequestHandler<CriarLancamentoRequest, GenericResponse>
    {

        public ILancamentoRepositorio _lancamentoRepo { get; set; }
        public ICategoriaRepositorio _categoriaRepo { get; set; }
        public IControleOrcamentario _controleOrcamentario { get; set; }
        public ICategoriaOrcamentoRepositorio _categoriaOrcamentoRepo { get; set; }


        public CriarLancamentoRequestHandler(ILancamentoRepositorio lancamentoRepo, ICategoriaRepositorio categoriaRepo, IControleOrcamentario controleOrcamento, ICategoriaOrcamentoRepositorio categoriaOrcamentoRepo)
        {
            _lancamentoRepo = lancamentoRepo;
            _categoriaRepo = categoriaRepo;
            _controleOrcamentario = controleOrcamento;
            _categoriaOrcamentoRepo = categoriaOrcamentoRepo;

        }

        public async Task<GenericResponse> Handle(CriarLancamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await _categoriaOrcamentoRepo.Consultar(request.UsuarioId, request.CategoriaId, request.ControleOrcamentarioId);

                if (categoria == null)
                {
                    throw new Exception("Categoria não encontrada.");
                }


                var lancamento
                    = new Lancamento(request.Nome, request.CategoriaId, categoria, request.Data ,request.Descricao, request.Tipo
                    ,request.Valor, request.UsuarioId, request.ControleOrcamentarioId);

                categoria.AtualizarValores(lancamento);

                await _categoriaOrcamentoRepo.Update(categoria);

                await _lancamentoRepo.Inserir(lancamento, request.CategoriaId);

                await _controleOrcamentario.IncluirLancamento(lancamento);

                await _controleOrcamentario.AtualizarValores(lancamento);


                return GenericResponse.Ok(lancamento);
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }
}
