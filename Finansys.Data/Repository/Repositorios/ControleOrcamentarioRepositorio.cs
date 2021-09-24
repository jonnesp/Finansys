using Finansys.Aplicacao.Interfaces;
using Finansys.Data.Conversor;
using Finansys.Data.Repository.Contexto;
using Finansys.Data.Repository.DTOs;
using Finansys.Dominio.Entidades;
using Finansys.Dominio.Enums;
using Finansys.Dominio.Fabricas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansys.Data.Repository.Repositorios
{
    public class ControleOrcamentarioRepositorio : IControleOrcamentario
    {
        public Context _context { get; set; }
        public DbSet<ControleOrcamentarioDTO> _dataset { get; set; }
        public ILancamentoFabrica LancamentoFabrica { get; set; }

        public ControleOrcamentarioRepositorio(Context context, ILancamentoFabrica lancamentoFabrica)
        {
            _context = context;
            _dataset = context.Set<ControleOrcamentarioDTO>();
            this.LancamentoFabrica = lancamentoFabrica;
        }

        public async Task IncluirLancamento(Lancamento lancamento)
        {
            try
            {
                var controleOrcamentario = _dataset.FirstOrDefault(x => x.ControleOrcamentarioId == lancamento.ControleOrcamentarioId);

                var lancamentoDTO = ConversorDTO.ConverterLancamentoParaLancamentoDTO(lancamento);

                controleOrcamentario.LancamentosDTOs.Add(lancamentoDTO);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task NovoOrcamento(ControleOrcamentario orcamento)
        {
            var orcamentoDto = new ControleOrcamentarioDTO(orcamento.ControleOrcamentarioId, orcamento.Inicio, orcamento.Fim, orcamento.MesReferencia, orcamento.ValorMensal, orcamento.UsuarioId);
            _dataset.Add(orcamentoDto);
            await _context.SaveChangesAsync();
        }

        public async Task<ControleOrcamentario> Consultar(string usuarioId, string controleOrcamentarioId)
        {
            var result = await _dataset.FirstOrDefaultAsync(x => x.ControleOrcamentarioId.Equals(controleOrcamentarioId));

            var controleConvertido = ConversorDTO.ConverterControleOrcamentarioParaControleOrcamentarioDTO(result, usuarioId);

            return controleConvertido;

        }

        public async Task AtualizarValores(Lancamento lancamento)
        {
            try
            {
                var controle = await _dataset.FirstOrDefaultAsync(x => x.ControleOrcamentarioId.Equals(lancamento.ControleOrcamentarioId));

                if(controle == null)
                {
                   await Task.FromResult("O ID do controle orcamentário não foi encontrado.");
                }

                if (lancamento.Data > controle.Inicio && lancamento.Data < controle.Fim)
                {
                    if (lancamento.TipoLancamento == TipoLancamento.Receita)
                    {
                        controle.Saldo += lancamento.Valor;
                        

                    }
                    if (lancamento.TipoLancamento == TipoLancamento.Despesa)
                    {
                        controle.Despesa += lancamento.Valor;
                    }
                    if ((lancamento.TipoLancamento) == TipoLancamento.Despesa && (controle.ValorMensal -= controle.Despesa) < 0)
                    {
                        controle.Despesa -= lancamento.Valor;
                       

                    }
                    else if (lancamento.TipoLancamento == TipoLancamento.Despesa && (controle.ValorMensal -= controle.Despesa) > 0)
                    {
                        controle.Saldo -= lancamento.Valor;
                        
                    }
                   
                }
                else
                {
                    throw new ArgumentException("Data fora do período permitido.");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

       
    }

}
