using System.Collections.Generic;
using System.Threading.Tasks;
using Finansys.Dominio.Entidades;

namespace Finansys.Aplicacao.Interfaces
{
    public interface ILancamentoRepositorio
    {
        Task Inserir(Lancamento lancamento, string categoriaId);
        Task Deletar(string id, string idUsuario);
        Task<bool> Atualizar(Lancamento lancamento);
        Task<Lancamento> Consultar(string id, string usuarioId);

        Task Apagar(string id, string usuarioId);

        Task<IEnumerable<Lancamento>> Buscar(string usuarioId);


    }
}
