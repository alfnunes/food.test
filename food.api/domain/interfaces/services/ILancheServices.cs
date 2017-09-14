using domain.model.inmemory;
using System.Collections.Generic;

namespace domain.interfaces.services
{
    public interface ILancheServices
    {
        IEnumerable<Lanche> RetornaTodosLanchesProntos();
        Lanche RetornaLancheCustomizado(IEnumerable<Ingrediente> ingredientes);
    }
}
