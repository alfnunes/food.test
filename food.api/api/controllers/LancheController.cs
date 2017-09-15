using Microsoft.AspNetCore.Mvc;
using domain.interfaces.services;
using System;
using domain.model.inmemory;
using System.Collections.Generic;

namespace api.controllers
{
    [Route("api/[controller]")]
    public class LancheController : Controller
    {
        private readonly ILancheServices _lanche;
        private readonly IIngredienteServices _ingrediente;      

        public LancheController(ILancheServices lanche)
        {
            _lanche = lanche;           
        }

        [HttpGet]
        [Route("padrao")]
        public IActionResult RetornaTodosLanchesProntos()
        {
            try
            {
                //retorna todos os lanches padrões do requisito              
                var lanches = _lanche.RetornaTodosLanchesProntos();
                return StatusCode(200, lanches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao obter os lanches prontos");
            }

        }

        [HttpPost]
        [Route("customizado")]
        public IActionResult RetornaLancheCustomizado([FromBody] IEnumerable<Ingrediente> ingredientes)
        {
            try
            {
                //retorna o lanche que o cliente montou
                var lanches = _lanche.RetornaLancheCustomizado(ingredientes);
                return StatusCode(200, lanches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao obter o lanche customizado");
            }
        }
    }
}
