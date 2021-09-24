using Finansys.Aplicacao.Interfaces;
using Finansys.Data.Repository.Contexto;
using Finansys.Data.Repository.DTOs;
using Finansys.Dominio.Entidades;
using Finansys.Dominio.Fabricas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansys.Data.Repository.Repositorios
{
    public class CategoriaOrcamentoRepositorio : ICategoriaOrcamentoRepositorio
    {
        public Context _context { get; set; }

        private readonly DbSet<CategoriaOrcamentoDTO> _dataSet;

        public ICategoriaOrcamentoFabrica CategoriaOrcamentoFabrica { get; set; }

        public CategoriaOrcamentoRepositorio(Context context, ICategoriaOrcamentoFabrica categoriaOrcamentoFabrica)
        {
            _context = context;
            _dataSet = _context.Set<CategoriaOrcamentoDTO>();
            CategoriaOrcamentoFabrica = categoriaOrcamentoFabrica;
        }

        public async Task Inserir(CategoriaOrcamento novaCategoria)
        {
           var categoriaOrcamentoDTO = new CategoriaOrcamentoDTO(novaCategoria.CategoriaId, novaCategoria.OrcamentoId, novaCategoria.ValorLimite, novaCategoria.UsuarioId);
            _dataSet.Add(categoriaOrcamentoDTO);
           await _context.SaveChangesAsync();
        }

        public async Task SaveChanges(CategoriaOrcamento cat)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.CategoriaId.Equals(cat.CategoriaId) && p.UsuarioId.Equals(cat.UsuarioId) && p.OrcamentoId.Equals(cat.OrcamentoId));
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(cat);
                    await _context.SaveChangesAsync();
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CategoriaOrcamento> Consultar(string usuarioId, string categoriaId, string controleOrcamentarioId)
        {
            try
            {
                var catDto = await _dataSet.SingleOrDefaultAsync(p => p.CategoriaId.Equals(categoriaId) && p.UsuarioId.Equals(usuarioId) && p.OrcamentoId.Equals(controleOrcamentarioId));
                return CategoriaOrcamentoFabrica.Criar(catDto.CategoriaId, catDto.OrcamentoId, catDto.ValorLimite,catDto.ValorJaGasto,catDto.SaldoDisponivel,catDto.ValorCreditado, usuarioId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(CategoriaOrcamento cat)
        {
            var result = await _dataSet.SingleOrDefaultAsync(p => p.CategoriaId.Equals(cat.CategoriaId) && p.UsuarioId.Equals(cat.UsuarioId) && p.OrcamentoId.Equals(cat.OrcamentoId));
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(cat);
                await _context.SaveChangesAsync();
            }
        }
    }
}
