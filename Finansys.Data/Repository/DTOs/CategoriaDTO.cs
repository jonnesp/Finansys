using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finansys.Data.Repository.DTOs
{
    [Table("Tb_Categorias")]
    public class CategoriaDTO
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

        

        public CategoriaDTO(string categoriaId, string usuarioId, string name, string descricao)
        {
            this.CategoriaId = categoriaId;
            UsuarioId = usuarioId;
            Name = name;
            Descricao = descricao;
        }
    }
}
