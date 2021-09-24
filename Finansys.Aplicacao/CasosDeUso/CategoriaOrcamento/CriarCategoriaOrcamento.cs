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
    public class CriarCategoriaOrcamentoRequest : IRequest<GenericResponse>
    {
        public string CategoriaId { get; set; }
        public string OrcamentoId { get; set; }
        public double ValorLimite { get; set; }
        public string UsuarioId { get; set; }
    }

    public class CriarCategoriaOrcamentoRequestHandler : IRequestHandler<CriarCategoriaOrcamentoRequest, GenericResponse>
    {

        public ICategoriaOrcamentoRepositorio CategoriaOrcamentoRepo { get; set; }
        public ICategoriaRepositorio CategoriaRepo { get; set; }
        public IControleOrcamentario OrcamentoRepo { get; set; }

        public CriarCategoriaOrcamentoRequestHandler(ICategoriaOrcamentoRepositorio categoriaOrcamentoRepo, ICategoriaRepositorio categoriaRepo, IControleOrcamentario orcamentoRepo)
        {
            CategoriaOrcamentoRepo = categoriaOrcamentoRepo;
            CategoriaRepo = categoriaRepo;
            OrcamentoRepo = orcamentoRepo;
        }

        public async Task<GenericResponse> Handle(CriarCategoriaOrcamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orcamentoLocalizado = await OrcamentoRepo.Consultar(request.UsuarioId, request.OrcamentoId);
                var categoriaLocalizada = await CategoriaRepo.Consultar(request.UsuarioId, request.CategoriaId);
                if(orcamentoLocalizado != null && categoriaLocalizada != null)
                {
                    var categoria = new CategoriaOrcamento(request.CategoriaId, request.OrcamentoId, request.ValorLimite, request.UsuarioId);
                    await CategoriaOrcamentoRepo.Inserir(categoria);
                    return GenericResponse.Ok(categoria);
                }

                return GenericResponse.Error("Categoria ou Orçamento não localizados.");
                
            }
            catch (Exception ex)
            {
                return GenericResponse.Error(ex.Message);
            }


        }
    }
}
