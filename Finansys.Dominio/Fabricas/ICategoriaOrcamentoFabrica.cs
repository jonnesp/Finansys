using Finansys.Dominio.Entidades;

namespace Finansys.Dominio.Fabricas
{
    public interface ICategoriaOrcamentoFabrica
    {
        CategoriaOrcamento Criar(string categoriaId, string orcamentoId, double valorLimite, double valorGasto, double saldoDisponivel, double valorCreditado, string usuarioId);
    }

    public class CategoriaOrcamentoFabrica : ICategoriaOrcamentoFabrica
    {
        public CategoriaOrcamento Criar(string categoriaId, string orcamentoId, double valorLimite, double valorGasto, double saldoDisponivel,double valorCreditado, string usuarioId)
        {
            return new CategoriaOrcamento(categoriaId, orcamentoId, valorLimite, valorGasto, valorCreditado, saldoDisponivel, usuarioId);
        }


    }
}
