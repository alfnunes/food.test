using domain.interfaces.repository.inmemory;
using domain.interfaces.services;
using domain.model.inmemory;
using System.Collections.Generic;

namespace domain.services
{
    public class IngredienteServices : IIngredienteServices
    {       
        private readonly IIngredienteRepository _ingredientes;

        public IngredienteServices(IIngredienteRepository ingredientes)
        {         
            _ingredientes = ingredientes;
        }

        public IEnumerable<Ingrediente> RetornaTodosIngredientes()
        {
            return _ingredientes.RetornaTodosIngredientes();
        }
    }
}
