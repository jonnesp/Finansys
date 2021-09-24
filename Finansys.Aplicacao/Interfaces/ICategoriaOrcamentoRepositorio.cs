using Finansys.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansys.Aplicacao.Interfaces
{
    public interface ICategoriaOrcamentoRepositorio
    {
        Task Inserir(CategoriaOrcamento novaCategoria);
        Task<CategoriaOrcamento> Consultar(string usuarioId, string categoriaId, string controleOrcamentarioId);
        public Task SaveChanges(CategoriaOrcamento cat);
        public Task Update(CategoriaOrcamento cat);
    }
}
