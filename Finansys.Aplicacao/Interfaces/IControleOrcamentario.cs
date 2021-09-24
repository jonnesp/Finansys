using Finansys.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansys.Aplicacao.Interfaces
{
    public interface IControleOrcamentario
    {
        public Task IncluirLancamento(Lancamento lancamento);
        public Task NovoOrcamento(ControleOrcamentario orcamento);
        Task<ControleOrcamentario> Consultar(string usuarioId, string controleOrcamentarioId);
        public Task AtualizarValores(Lancamento lancamento);
        
    }
}
