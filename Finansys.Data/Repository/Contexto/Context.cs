using System;
using Finansys.Data.Repository.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Finansys.Data.Repository.Contexto
{
    public class Context : DbContext
    {
        public DbSet<CategoriaDTO> Categorias { get; set; }
        public DbSet<LancamentoDTO> Lancamentos { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }


    }
}
