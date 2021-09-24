using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finansys.Dominio.Enums;

namespace Finansys.Dominio.Entidades
{
    public class ControleOrcamentario
    {
        public string ControleOrcamentarioId { get; set; }

        public DateTime Inicio { get; private set; }

        public DateTime Fim { get; private set; }

        public string MesReferencia { get; private set; }

        public double ValorMensal { get; set; }

        public string UsuarioId { get; set; }

        public double Despesa { get; set; }

        public double Saldo { get; set; }

        public ControleOrcamentario(DateTime inicio, DateTime fim, string mesReferencia, double valorMensal, string usuarioId)
        {
            ControleOrcamentarioId = Guid.NewGuid().ToString();
            Inicio = inicio;
            Fim = fim;
            MesReferencia = mesReferencia;
            ValorMensal = valorMensal;
            this.UsuarioId = usuarioId;
        }
    }
}

