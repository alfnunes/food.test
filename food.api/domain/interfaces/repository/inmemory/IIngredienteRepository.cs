using domain.model.inmemory;
using System.Collections.Generic;
using System.Threading.Tasks;
using static domain.model.inmemory.Ingrediente;

namespace domain.interfaces.repository.inmemory
{
    public interface IIngredienteRepository
    {
        IEnumerable<Ingrediente> RetornaTodosIngredientes();
        Task<IEnumerable<Ingrediente>> RetornaTodosIngredientesAsync();
        Ingrediente RetornaIngredientesPorNome(IngredienteEnum nome);
        Task<Ingrediente> RetornaIngredientesPorNomeAsync(IngredienteEnum nome);
    }
}
