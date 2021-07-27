using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Finansys.Dominio.Entidades;

namespace Finansys.Dominio.Raizes_Agregacao
{
    public class Usuario
    {
        [Key]
        public string Id { get; set; }

        public List<Lancamento> Lancamentos { get; private set; }
        public List<Lancamento> Categorias { get; private set; }




    }
}
