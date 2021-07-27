using Finansys.Dominio.Entidades;

namespace Finansys.Dominio.Fabricas
{
    public interface ICategoriaFabrica
    {
        Categoria Criar(string id, string usuarioId, string name, string descricao);
    }

    public class CategoriaFabrica : ICategoriaFabrica
    {
        public Categoria Criar(string id, string usuarioId, string name, string descricao)
        {
            return new Categoria(id, usuarioId, name, descricao);
        }


    }
}
