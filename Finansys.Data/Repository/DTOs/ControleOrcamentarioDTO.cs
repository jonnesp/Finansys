using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansys.Data.Repository.DTOs
{
    public class ControleOrcamentarioDTO
    {
        [Key]
        [MaxLength(50)]
        public string ControleOrcamentarioId { get; set; }

        public DateTime Inicio { get; private set; }

        public DateTime Fim { get; private set; }

        public string MesReferencia { get; private set; }

        public double ValorMensal { get; set; }

        public List<LancamentoDTO> LancamentosDTOs = new List<LancamentoDTO>();

        public string UsuarioId { get; set; }

        public double Despesa { get; set; }

        public double Saldo { get; set; }

        public ControleOrcamentarioDTO(string controleOrcamentarioId, DateTime inicio, DateTime fim, string mesReferencia, double valor, string usuarioId)
        {
            ControleOrcamentarioId = controleOrcamentarioId;
            Inicio = inicio;
            Fim = fim;
            MesReferencia = mesReferencia;
            ValorMensal = valor;
            this.UsuarioId = usuarioId;
        }
        public ControleOrcamentarioDTO()
        {

        }
    }
}

