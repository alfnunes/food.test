using domain.helper;
using domain.interfaces.repository.inmemory;
using domain.model.inmemory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static domain.model.inmemory.Ingrediente;

namespace infrastruture.inmemory.repositories
{
    public class IngredienteRepository : IIngredienteRepository
    {
        internal IEnumerable<Ingrediente> _ingredientes = new List<Ingrediente>
        {
            new Ingrediente { Nome = IngredienteEnum.ALFACE.ToDescription(), Valor = 0.40M },
            new Ingrediente { Nome = IngredienteEnum.BACON.ToDescription(), Valor = 2.00M },
            new Ingrediente { Nome = IngredienteEnum.CARNE.ToDescription(), Valor = 3.00M },
            new Ingrediente { Nome = IngredienteEnum.OVO.ToDescription(), Valor = 0.80M },
            new Ingrediente { Nome = IngredienteEnum.QUEIJO.ToDescription(), Valor = 1.50M }
        };

        public IEnumerable<Ingrediente> RetornaTodosIngredientes()
        {
            return _ingredientes;
        }

        public async Task<IEnumerable<Ingrediente>> RetornaTodosIngredientesAsync()
        {
            return await Task.Run(() =>
            {
                return _ingredientes;
            });
        }

        public Ingrediente RetornaIngredientesPorNome(IngredienteEnum nome)
        {            
            return _ingredientes.FirstOrDefault(i => i.Nome == nome.ToDescription());
        }

        public async Task<Ingrediente> RetornaIngredientesPorNomeAsync(IngredienteEnum nome)
        {
            return await Task.Run(() =>
            {
                return _ingredientes.FirstOrDefault(i => i.Nome == nome.ToDescription());
            });
        }
    }
}
