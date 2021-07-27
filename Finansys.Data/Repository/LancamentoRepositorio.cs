using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finansys.Aplicacao.Interfaces;
using Finansys.Data.Repository.Contexto;
using Finansys.Data.Repository.DTOs;
using Finansys.Dominio.Entidades;
using Finansys.Dominio.Fabricas;
using Microsoft.EntityFrameworkCore;

namespace Finansys.Data.Repository
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        protected readonly Context _context;
        private DbSet<LancamentoDTO> _dataSet;

        private DbSet<CategoriaDTO> _categoriaDTO;

        private ILancamentoFabrica _lancamentoFabrica;

        public LancamentoRepositorio(Context context, ILancamentoFabrica lancamentoFabrica)
        {
            _context = context;
            _dataSet = context.Set<LancamentoDTO>();
            _categoriaDTO = _context.Set<CategoriaDTO>();
            _lancamentoFabrica = lancamentoFabrica;
        }
        public async Task Apagar(string lancamentoId, string usuarioId)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.LancamentoId.Equals(lancamentoId) && p.UsuarioId.Equals(usuarioId));
                if (result != null)
                {
                    _dataSet.Remove(result);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Atualizar(Lancamento lancamento)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.LancamentoId == lancamento.LancamentoId);
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(lancamento);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Lancamento>> Buscar(string usuarioId)
        {
            try
            {
                List<Lancamento> lancamentos = new List<Lancamento>();
                foreach (var x in await _dataSet.Where(x => x.UsuarioId == usuarioId).ToListAsync())
                {
                    var categoriaDto = await _categoriaDTO.SingleOrDefaultAsync(p => p.CategoriaId == x.CategoriaId);
                    var cat = ConversorDTO.converterCategoriaDTOParaCategoria(categoriaDto);
                    lancamentos.Add(_lancamentoFabrica.Criar(x.LancamentoId, x.Nome, cat,x.Data, x.Descricao, x.TipoLancamento
                                      , x.Valor, x.UsuarioId));
                }
                return lancamentos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Lancamento> Consultar(string lancamentoId, string usuarioId)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.LancamentoId.Equals(lancamentoId) && p.UsuarioId.Equals(usuarioId));
                if (result != null)
                {
                    var lancamentoDto = result;
                    var categoriaDto = await _categoriaDTO.SingleOrDefaultAsync(x => x.CategoriaId == lancamentoDto.CategoriaId);
                    var cat = ConversorDTO.converterCategoriaDTOParaCategoria(categoriaDto);
                    return _lancamentoFabrica.Criar(lancamentoId, lancamentoDto.Nome, cat, lancamentoDto.Data, lancamentoDto.Descricao, lancamentoDto.TipoLancamento
                                          , lancamentoDto.Valor, lancamentoDto.UsuarioId);
                }
                else
                {
                    return new Lancamento();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Deletar(string lancamentoId, string usuarioId)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.LancamentoId.Equals(lancamentoId) && p.UsuarioId.Equals(usuarioId));
                if (result != null)
                {
                    _dataSet.Remove(result);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Inserir(Lancamento lancamento, string CategoriaId)
        {
            try
            {
                var lancamentoDto = new LancamentoDTO(lancamento.LancamentoId, lancamento.Nome, CategoriaId,lancamento.Data, lancamento.Descricao
                                                        , lancamento.TipoLancamento, lancamento.Valor, lancamento.UsuarioId);

                _dataSet.Add(lancamentoDto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
