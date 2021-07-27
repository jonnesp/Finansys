using System;
using Finansys.Dominio.Entidades;
using Finansys.Dominio.Enums;

namespace Finansys.Dominio.Fabricas
{
    public interface ILancamentoFabrica
    {
        Lancamento Criar(string lancamentoId, string nome, Categoria cat,DateTime data, string descricao, TipoLancamento tipo, double valor, string usuarioId);
    }

    public class LancamentoFabrica : ILancamentoFabrica
    {
        public Lancamento Criar(string lancamentoId, string nome, Categoria cat, DateTime data, string descricao, TipoLancamento tipo, double valor, string usuarioId)
        {
            return new Lancamento(lancamentoId, nome, cat, data, descricao, tipo, valor, usuarioId);
        }
    }
}
