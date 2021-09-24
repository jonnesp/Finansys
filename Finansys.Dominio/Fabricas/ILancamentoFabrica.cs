using System;
using Finansys.Dominio.Entidades;
using Finansys.Dominio.Enums;

namespace Finansys.Dominio.Fabricas
{
    public interface ILancamentoFabrica
    {
        Lancamento Criar(string lancamentoId, string nome, CategoriaOrcamento cat,DateTime data, string descricao, TipoLancamento tipo, double valor, string usuarioId, string controleOrcamentarioId);
    }

    public class LancamentoFabrica : ILancamentoFabrica
    {
        public Lancamento Criar(string lancamentoId, string nome, CategoriaOrcamento cat, DateTime data, string descricao, TipoLancamento tipo, double valor, string usuarioId, string controleOrcamentarioId)
        {
            return new Lancamento(lancamentoId, nome, cat, data, descricao, tipo, valor, usuarioId, controleOrcamentarioId);
        }
    }
}
