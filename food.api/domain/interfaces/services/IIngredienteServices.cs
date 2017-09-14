using domain.model.inmemory;
using System.Collections.Generic;

namespace domain.interfaces.services
{
    public interface IIngredienteServices
    {
        IEnumerable<Ingrediente> RetornaTodosIngredientes();
    }
}
