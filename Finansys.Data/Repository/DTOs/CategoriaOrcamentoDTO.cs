using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansys.Data.Repository.DTOs
{
    public class CategoriaOrcamentoDTO
    {
        [Key]
        public string CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public CategoriaDTO CategoriaDTO { get; set; }
        [Key]
        public string OrcamentoId { get; set; }
        [ForeignKey("OrcamentoId")]
        public ControleOrcamentarioDTO OrcamentoDTO { get; set; }

        public double ValorLimite { get; set; }
        public double ValorJaGasto { get; set; }
        public double ValorCreditado { get;  set; }
        public double SaldoDisponivel { get;  set; }
        public string UsuarioId { get; set; }

        public CategoriaOrcamentoDTO(string categoriaId, string orcamentoId, double valorLimite, string usuarioId)
        {
            CategoriaId = categoriaId;
            OrcamentoId = orcamentoId;
            ValorLimite = valorLimite;
            UsuarioId = usuarioId;
        }

        public CategoriaOrcamentoDTO(string categoriaId, string orcamentoId, double valorLimite,double valorJaGasto,double valorCreditado,double saldoDisponivel ,string usuarioId)
        {
            CategoriaId = categoriaId;
            OrcamentoId = orcamentoId;
            ValorLimite = valorLimite;
            UsuarioId = usuarioId;
            ValorJaGasto = valorJaGasto;
            ValorCreditado = valorCreditado;
            SaldoDisponivel = saldoDisponivel;
        }
    }
}
