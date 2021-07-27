using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Finansys.Aplicacao.Interfaces;
using System.Linq;
using Finansys.Data.Repository.Contexto;
using Finansys.Data.Repository.DTOs;
using Finansys.Dominio.Entidades;
using Finansys.Dominio.Fabricas;
using Microsoft.EntityFrameworkCore;

namespace Finansys.Data.Repository
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {

        protected readonly Context _context;

        public ICategoriaFabrica CategoriaFabrica { get; set; }

        private DbSet<CategoriaDTO> _dataSet;

        private ICategoriaFabrica _categoriaFabrica;

        public CategoriaRepositorio(Context context, ICategoriaFabrica fabrica, ICategoriaFabrica categoriaFabrica)
        {
            _context = context;
            CategoriaFabrica = fabrica;
            _dataSet = context.Set<CategoriaDTO>();
            _categoriaFabrica = categoriaFabrica;
        }

        public async Task<bool> Apagar(string usuarioId, string categoriaId)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.CategoriaId.Equals(categoriaId) && p.UsuarioId.Equals(usuarioId));
                if (result != null)
                {
                    _dataSet.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Atualizar(Categoria categoria)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.CategoriaId == categoria.CategoriaId);
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(categoria);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Categoria>> Buscar(string usuarioid)
        {
            try
            {
                List<Categoria> cat = new List<Categoria>();
                foreach (var x in await _dataSet.Where(x => x.UsuarioId == usuarioid).ToListAsync())
                {
                    cat.Add(_categoriaFabrica.Criar(x.CategoriaId, x.Name, x.Descricao, x.UsuarioId));
                }
                return cat;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Categoria> Consultar(string usuarioId, string categoriaId)
        {
            try
            {
                var catDto = await _dataSet.SingleOrDefaultAsync(p => p.CategoriaId.Equals(categoriaId) && p.UsuarioId.Equals(usuarioId));
                return _categoriaFabrica.Criar(catDto.CategoriaId, catDto.UsuarioId, catDto.Name, catDto.Descricao);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Inserir(Categoria categoria)
        {
            try
            {
                var catDto = new CategoriaDTO(categoria.CategoriaId, categoria.UsuarioId, categoria.Name, categoria.Descricao);
                _dataSet.Add(catDto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
