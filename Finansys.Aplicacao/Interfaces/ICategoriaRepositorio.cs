using System.Collections.Generic;
using System.Threading.Tasks;
using Finansys.Dominio.Entidades;

namespace Finansys.Aplicacao.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task Inserir(Categoria categoria);

        Task Atualizar(Categoria categoria);

        Task<Categoria> Consultar(string usuarioId, string categoriaId);

        Task<bool> Apagar(string usuarioId, string id);

        Task<IEnumerable<Categoria>> Buscar(string categoriaId);

    }
}
