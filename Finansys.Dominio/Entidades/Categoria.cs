using System;
using System.ComponentModel.DataAnnotations;

namespace Finansys.Dominio.Entidades
{
    public class Categoria
    {


        public string CategoriaId { get; private set; }
        public string UsuarioId { get; set; }
        public string Name { get; private set; }
        public string Descricao { get; private set; }

        public Categoria(string name, string descricao, string usuarioId)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nome Obrigatório");
            }
            if (String.IsNullOrEmpty(usuarioId))
            {
                throw new ArgumentNullException("Usuario Obrigatório");
            }
            this.CategoriaId = Guid.NewGuid().ToString();
            this.UsuarioId = usuarioId;
            this.Name = name;
            this.Descricao = descricao;
        }

        internal Categoria(string id, string usuarioId, string name, string descricao)
        {
            this.CategoriaId = id;
            this.UsuarioId = usuarioId;
            this.Name = name;
            this.Descricao = descricao;

        }


        public void AlterarCategoria(string name, string descricao)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nome Obrigatório");
            }
            this.Name = name;
            this.Descricao = descricao;
        }
    }
}
