using Finansys.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansys.Dominio.Entidades
{
    public class CategoriaOrcamento
    {
        public string CategoriaId { get; private set; }
        public string OrcamentoId { get; private set; }
        public double ValorLimite { get; private set; }
        public double ValorJaGasto { get; private set; }
        public double ValorCreditado { get; private set; }
        public double SaldoDisponivel { get; private set; }
        public string UsuarioId { get; private set; }


        public CategoriaOrcamento(string categoriaId, string orcamentoId, double valorLimite, double valorGasto,double valorCreditado,double saldoDisponivel, string usuarioId)
        {

            CategoriaId = categoriaId;
            OrcamentoId = orcamentoId;
            ValorLimite = valorLimite;
            UsuarioId = usuarioId;
            ValorJaGasto = valorGasto;
            ValorCreditado = valorCreditado;
            SaldoDisponivel = saldoDisponivel;
        }

        public CategoriaOrcamento(string categoriaId, string orcamentoId, double valorLimite, string usuarioId)
        {

            CategoriaId = categoriaId;
            OrcamentoId = orcamentoId;
            ValorLimite = valorLimite;
            UsuarioId = usuarioId;
        }

        public void AlterarCategoriaOrcamento(double valorLimite)
        {
            ValorLimite = valorLimite;
        }

        public void AtualizarValores(Lancamento lancamento)
        {
            if (lancamento.TipoLancamento == TipoLancamento.Despesa)
            {
                ValorJaGasto += lancamento.Valor;
                SaldoDisponivel = ValorLimite - ValorJaGasto;
            }
            else
            {
                ValorCreditado += lancamento.Valor;
                SaldoDisponivel = ValorLimite - ValorJaGasto;
            }
        }

    }
}
