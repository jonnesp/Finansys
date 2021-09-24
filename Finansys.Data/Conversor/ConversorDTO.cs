using Finansys.Data.Repository.DTOs;
using Finansys.Dominio.Entidades;
using Finansys.Dominio.Fabricas;

namespace Finansys.Data.Conversor
{
    public static class ConversorDTO
    {

        public static Categoria ConverterCategoriaDTOParaCategoria(CategoriaDTO categoria)
        {
            var _teste = new CategoriaFabrica();
            return _teste.Criar(categoria.CategoriaId, categoria.UsuarioId, categoria.Name, categoria.Descricao);
        }

        public static LancamentoDTO ConverterLancamentoParaLancamentoDTO(Lancamento lancamento)
        {
            return new LancamentoDTO(lancamento.LancamentoId, lancamento.Nome, lancamento.CategoriaOrcamentoId, lancamento.Data, lancamento.Descricao
                                                        , lancamento.TipoLancamento, lancamento.Valor, lancamento.UsuarioId, lancamento.ControleOrcamentarioId);
        }

        public static ControleOrcamentario ConverterControleOrcamentarioParaControleOrcamentarioDTO(ControleOrcamentarioDTO controleOrcamentario, string usuarioId)
        {
            return new ControleOrcamentario(controleOrcamentario.Inicio, controleOrcamentario.Fim, controleOrcamentario.MesReferencia, controleOrcamentario.ValorMensal, usuarioId);
        }

        public static CategoriaOrcamento ConverterCategoriaOrcamentoDTOParaCategoriaOrcamento(CategoriaOrcamentoDTO cat)
        {
            return new CategoriaOrcamento(cat.CategoriaId, cat.OrcamentoId, cat.ValorLimite, cat.UsuarioId);
        }

    }
}
