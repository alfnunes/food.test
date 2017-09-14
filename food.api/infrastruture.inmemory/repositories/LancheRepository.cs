using domain.helper;
using domain.interfaces.repository.inmemory;
using domain.model.inmemory;
using System.Collections.Generic;
using System.Linq;
using static domain.model.inmemory.Ingrediente;

namespace infrastruture.inmemory.repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly IIngredienteRepository _ingredienteRepository;

        public LancheRepository(IIngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        private List<Ingrediente> RetornaXburger()
        {
            return new List<Ingrediente> {
                _ingredienteRepository.RetornaIngredientesPorNome(IngredienteEnum.CARNE),
                _ingredienteRepository.RetornaIngredientesPorNome(IngredienteEnum.QUEIJO)
            };
        }

        private List<Ingrediente> RetornaXBacon()
        {
            var xburguer = RetornaXburger();
            xburguer.Add(_ingredienteRepository.RetornaIngredientesPorNome(IngredienteEnum.BACON));
            return xburguer;
        }

        private List<Ingrediente> RetornaXEgg()
        {
            var xburguer = RetornaXburger();
            xburguer.Add(_ingredienteRepository.RetornaIngredientesPorNome(IngredienteEnum.OVO));
            return xburguer;
        }

        private List<Ingrediente> RetornaXEggBacon()
        {
            return _ingredienteRepository.RetornaTodosIngredientes().Where(i => i.Nome != IngredienteEnum.ALFACE.ToDescription()).ToList();
        }
        
        public List<Lanche> RetornaTodosLanchesProntos()
        {
            return new List<Lanche>
            {
                new Lanche { Nome = "X-Bacon",  Ingredientes = RetornaXBacon() },
                new Lanche { Nome = "X-Burger", Ingredientes = RetornaXburger()  },
                new Lanche { Nome = "X-Egg", Ingredientes = RetornaXEgg()  },
                new Lanche { Nome = "X-Egg Bacon", Ingredientes = RetornaXEggBacon()  }
            };
        }
    }
}
