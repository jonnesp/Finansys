using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finansys.Aplicacao.Interfaces;
using Finansys.Data.Conversor;
using Finansys.Data.Repository.Contexto;
using Finansys.Data.Repository.DTOs;
using Finansys.Dominio.Entidades;
using Finansys.Dominio.Fabricas;
using Microsoft.EntityFrameworkCore;

namespace Finansys.Data.Repository.Repositorios
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        protected readonly Context _context;

        private DbSet<LancamentoDTO> _dataSet;

        private DbSet<CategoriaOrcamentoDTO> _categoriaOrcamentoDTO;

        private ILancamentoFabrica _lancamentoFabrica;

        public LancamentoRepositorio(Context context, ILancamentoFabrica lancamentoFabrica)
        {
            _context = context;
            _dataSet = context.Set<LancamentoDTO>();
            _categoriaOrcamentoDTO = _context.Set<CategoriaOrcamentoDTO>();
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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Lancamento>> Buscar(string usuarioId)
        {
            try
            {
                List<Lancamento> lancamentos = new List<Lancamento>();
                foreach (var x in await _dataSet.Where(x => x.UsuarioId == usuarioId).ToListAsync())
                {
                    var categoriaOrcamentoDto = await _categoriaOrcamentoDTO.SingleOrDefaultAsync(p => p.CategoriaId == x.CategoriaId);

                    var cat = ConversorDTO.ConverterCategoriaOrcamentoDTOParaCategoriaOrcamento(categoriaOrcamentoDto);

                    lancamentos.Add(_lancamentoFabrica.Criar(x.LancamentoId, x.Nome, cat, x.Data, x.Descricao, x.TipoLancamento
                                      , x.Valor, x.UsuarioId, x.ControleOrcamentarioId));
                }
                return lancamentos;
            }
            catch (Exception)
            {
                throw;
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
                    var categoriaDto = await _categoriaOrcamentoDTO.SingleOrDefaultAsync(x => x.CategoriaId == lancamentoDto.CategoriaId);
                    var cat = ConversorDTO.ConverterCategoriaOrcamentoDTOParaCategoriaOrcamento(categoriaDto);

                    return _lancamentoFabrica.Criar(lancamentoId, lancamentoDto.Nome, cat, lancamentoDto.Data, lancamentoDto.Descricao, lancamentoDto.TipoLancamento
                                          , lancamentoDto.Valor, lancamentoDto.UsuarioId, lancamentoDto.ControleOrcamentarioId);
                }
                else
                {
                    return new Lancamento();
                }
            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Inserir(Lancamento lancamento, string CategoriaId)
        {
            try
            {
                var lancamentoDto = new LancamentoDTO(lancamento.LancamentoId, lancamento.Nome, CategoriaId, lancamento.Data, lancamento.Descricao
                                                        , lancamento.TipoLancamento, lancamento.Valor, lancamento.UsuarioId, lancamento.ControleOrcamentarioId);

                _dataSet.Add(lancamentoDto);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
