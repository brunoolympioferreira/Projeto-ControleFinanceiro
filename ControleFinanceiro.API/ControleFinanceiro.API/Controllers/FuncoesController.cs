﻿using ControleFinanceiro.API.ViewModels;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncoesController : ControllerBase
    {
        #region Construtor
        private readonly IFuncaoRepositorio _funcaoRepositorio;

        public FuncoesController(IFuncaoRepositorio funcaoRepositorio)
        {
            _funcaoRepositorio = funcaoRepositorio;
        }
        #endregion

        #region PegarTodos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcao>>> GetFuncoes()
        {
            return await _funcaoRepositorio.PegarTodos().ToListAsync();
        }
        #endregion

        #region PegarPeloId
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcao>> GetFuncao(string id)
        {
            var funcao = await _funcaoRepositorio.PegarPeloId(id);
            if (funcao == null)
            {
                return NotFound();
            }

            return funcao;
        }
        #endregion

        #region Atualizar
        [HttpPut("{id}")]
        public async Task<ActionResult> PutFuncao(string id, FuncoesViewModel funcoes)
        {
            if (id != funcoes.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Funcao funcao = new Funcao
                {
                    Id = funcoes.Id,
                    Name = funcoes.Name,
                    Descricao = funcoes.Descricao
                };

                await _funcaoRepositorio.AtualizarFuncao(funcao);

                return Ok(new
                {
                    mensagem = $"Funcao {funcao.Name} atualizada com sucesso"
                });
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Inserir
        [HttpPost]
        public async Task<ActionResult> PostFuncao(FuncoesViewModel funcoes)
        {
            if (ModelState.IsValid)
            {
                Funcao funcao = new Funcao
                {
                    Name = funcoes.Name,
                    Descricao = funcoes.Descricao
                };

                await _funcaoRepositorio.AdicionarFuncao(funcao);

                return Ok(new
                {
                    mensagem = $"Funcao {funcao.Name} adicionada com sucesso"
                });
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Deletar
        [HttpDelete("{id}")]
        public async Task<ActionResult<Funcao>> DeleteFuncao(string id)
        {
            var funcao = await _funcaoRepositorio.PegarPeloId(id);
            if (funcao == null)
            {
                return NotFound();
            }
            await _funcaoRepositorio.Excluir(funcao);

            return Ok(new
            {
                mensagem = $"Funcao {funcao.Name} excluída com sucesso"
            });


        }
        #endregion

        #region Filtrar
        [HttpGet("FiltrarFuncoes/{nomeFuncao}")]
        public async Task<ActionResult<IEnumerable<Funcao>>> FiltrarFuncoes(string nomeFuncao)
        {
            return await _funcaoRepositorio.FiltrarFuncoes(nomeFuncao).ToListAsync();
        }
        #endregion
    }
}