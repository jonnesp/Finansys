using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansys.Data.Repository.DTOs
{
    class ControleOrcamentarioDTO
    {
        [Key]
        [MaxLength(50)]
        public string CategoriaId { get; set; }

        [MaxLength(50)]
        public string UsuarioId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        public CategoriaDTO(string CategoriaId, string usuarioId, string name, string descricao)
        {
            this.CategoriaId = CategoriaId;
            UsuarioId = usuarioId;
            Name = name;
            Descricao = descricao;
        }
    }
}
}
