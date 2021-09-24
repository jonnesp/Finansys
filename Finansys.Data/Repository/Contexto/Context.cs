using System;
using Finansys.Data.Repository.DTOs;
using Finansys.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Finansys.Data.Repository.Contexto
{
    public class Context : DbContext
    {
        public DbSet<CategoriaDTO> Categorias { get; set; }
        public DbSet<LancamentoDTO> Lancamentos { get; set; }
        public DbSet<CategoriaOrcamentoDTO> CategoriaOrcamento { get; set; }
        public DbSet<ControleOrcamentarioDTO> ControleOrcamentarioDTOs { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoriaOrcamentoDTO>().HasKey(x => new { x.CategoriaId, x.OrcamentoId });
        }

    }
}
