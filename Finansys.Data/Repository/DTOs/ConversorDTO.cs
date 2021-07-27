using Finansys.Dominio.Entidades;
using Finansys.Dominio.Fabricas;

namespace Finansys.Data.Repository.DTOs
{
    public static class ConversorDTO
    {

        public static Categoria converterCategoriaDTOParaCategoria(CategoriaDTO categoria)
        {
            var _teste = new CategoriaFabrica();
            return _teste.Criar(categoria.CategoriaId, categoria.UsuarioId, categoria.Name, categoria.Descricao);
        }
    }
}
