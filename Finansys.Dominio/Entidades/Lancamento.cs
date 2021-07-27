using System;
using System.ComponentModel.DataAnnotations;
using Finansys.Dominio.Enums;
using Finansys.Dominio.Raizes_Agregacao;

namespace Finansys.Dominio.Entidades
{
    public class Lancamento
    {

        public string LancamentoId { get; private set; }

        public string UsuarioId { get; private set; }

        public string Nome { get; private set; }

        public string CategoriaId { get; set; }

        public Categoria Categoria { get; private set; }

        public DateTime Data { get; private set; }

        public string Descricao { get; private set; }

        public TipoLancamento TipoLancamento { get; private set; }

        public double Valor { get; private set; }




        
        public Lancamento(string nome, string categoriaId, Categoria cat,DateTime data, string descricao, TipoLancamento tipo, double valor, string usuarioId)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException("O nome deve ser preenchido.");
            }
            if (String.IsNullOrEmpty(usuarioId))
            {
                throw new ArgumentNullException("O Usuario deve ser preenchido.");
            }
            if (cat == null)
            {
                throw new ArgumentNullException("Deve existir uma categoria.");
            }
            
            this.LancamentoId = Guid.NewGuid().ToString();
            this.Nome = nome;
            this.Categoria = cat;
            this.CategoriaId = categoriaId;
            this.Data = data;
            this.Descricao = descricao;
            this.TipoLancamento = tipo;
            this.Valor = valor;
            this.UsuarioId = usuarioId;
        }
        public Lancamento()
        {

        }

        public void AlterarDados(string nome, string cat, DateTime data,string descricao, TipoLancamento tipo, double valor)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException("O nome deve ser preenchido.");
            }
            if (cat == null)
            {
                throw new ArgumentNullException("Deve existir uma categoria.");
            }
            // if (data.Date > DateTime.Today)
            // {
            //     throw new ArgumentException("A data deve ser menor que a data atual");
            // }

            this.Nome = nome;
            this.CategoriaId = cat;
            this.Data = data;
            this.Descricao = descricao;
            this.TipoLancamento = tipo;
            this.Valor = valor;
        }

        public bool IsPago()
        {
            return DateTime.UtcNow >= Data;
        }



    }
}
