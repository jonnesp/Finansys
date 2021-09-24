using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finansys.Dominio.Entidades;
using Finansys.Dominio.Enums;
using Finansys.Dominio.Fabricas;

namespace Finansys.Data.Repository.DTOs
{
    [Table("Tb_Lancamentos")]
    public class LancamentoDTO
    {

        [Key]
        [MaxLength(50)]
        public string LancamentoId { get; private set; }

        [MaxLength(50)]
        public string UsuarioId { get; private set; }

        [MaxLength(100)]
        [Required]
        public string Nome { get; private set; }


        [ForeignKey("CategoriaDTO")]
        [MaxLength(50)]
        public string CategoriaId { get; set; }
        public CategoriaDTO Categoria { get; private set; }

        [Required]
        public DateTime Data { get; private set; }

        [MaxLength(255)]
        public string Descricao { get; private set; }

        [Required]
        public TipoLancamento TipoLancamento { get; private set; }

        [Required]
        public double Valor { get; private set; }

        public string ControleOrcamentarioId { get;  set; }

        [ForeignKey("ControleOrcamentarioId")]
        public ControleOrcamentarioDTO ControleOrcamentarioDTO { get; set;  }

        public LancamentoDTO(string LancamentoId, string Nome, string CategoriaId, DateTime data,string descricao, TipoLancamento TipoLancamento, double valor, string usuarioId,string controleOrcamentarioId)
        {
            this.LancamentoId = LancamentoId;
            this.Nome = Nome;
            this.CategoriaId = CategoriaId;
            this.Data = data;
            this.Descricao = descricao;
            this.TipoLancamento = TipoLancamento;
            this.Valor = valor;
            this.UsuarioId = usuarioId;
            this.ControleOrcamentarioId = controleOrcamentarioId;
        }



    }
}
