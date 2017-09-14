using domain.interfaces.repository.inmemory;
using domain.interfaces.services;
using domain.model.inmemory;
using System.Collections.Generic;
using System.Linq;

namespace domain.services
{
    public class LancheServices : ILancheServices
    {
        private readonly ILancheRepository _lanche;
        private readonly IIngredienteRepository _ingredientes;

        public LancheServices(ILancheRepository lanche, IIngredienteRepository ingredientes)
        {
            _lanche = lanche;
            _ingredientes = ingredientes;
        }

        public IEnumerable<Lanche> RetornaTodosLanchesProntos()
        {
            var lanches = _lanche.RetornaTodosLanchesProntos();

            lanches.ForEach(l =>
            {
                l.Total = l.Ingredientes.Sum(i => i.Valor);
            });

            return lanches;
        }

        public Lanche RetornaLancheCustomizado(IEnumerable<Ingrediente> ingredientes)
        {         
            return new Lanche { Nome = "Lanche Customizado", Ingredientes = ingredientes, Total = ingredientes.Sum(i => i.Valor) };
        }

    }
}
