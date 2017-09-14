using domain.model.inmemory;
using System.Collections.Generic;

namespace domain.interfaces.repository.inmemory
{
    public interface ILancheRepository
    {
        List<Lanche> RetornaTodosLanchesProntos();
    }
}
