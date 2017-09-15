using Microsoft.AspNetCore.Mvc;
using domain.interfaces.services;
using System;

namespace api.controllers
{
    [Route("api/[controller]")]
    public class IngredienteController : Controller
    {
        private readonly IIngredienteServices _ingrediente;      

        public IngredienteController(IIngredienteServices ingrediente)
        {
            _ingrediente = ingrediente;           
        }

        [HttpGet]
        [Route("all")]
        public IActionResult RetornaTodosIngredientes()
        {
            try
            {
                //retorna todos os ingredientes padrões do requisito
                var ingredientes = _ingrediente.RetornaTodosIngredientes();
                return StatusCode(200, ingredientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
