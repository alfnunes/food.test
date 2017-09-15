using domain.interfaces.repository.inmemory;
using domain.interfaces.services;
using domain.model.inmemory;
using domain.services;
using infrastruture.inmemory.repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using static domain.model.inmemory.Ingrediente;
using domain.helper;

namespace teste
{
    [TestClass]
    public class LancheTest
    {
        internal IIngredienteRepository _ingredienteRepository;
        internal ILancheRepository _lancheRepository;
        internal IIngredienteServices _ingredienteServices;
        internal ILancheServices _lancheServices;
        private List<Ingrediente> _ingredientes;

        [TestInitialize()]
        public void Initialize()
        {
            _ingredienteRepository = new IngredienteRepository();
            _lancheRepository = new LancheRepository(_ingredienteRepository);
            _ingredienteServices = new IngredienteServices(_ingredienteRepository);
            _lancheServices = new LancheServices(_lancheRepository, _ingredienteRepository);

            _ingredientes = _ingredienteRepository.RetornaTodosIngredientes().ToList();
        }      

        [TestMethod]
        public void verifica_valor_x_bacon()
        {
            var esperado = 6.5M;
            var atual = _lancheServices.RetornaTodosLanchesProntos().Where(l => l.Nome == "X-Bacon").FirstOrDefault();

            Assert.AreEqual(esperado, atual.Total);
        }

        [TestMethod]
        public void verifica_valor_x_burger()
        {
            var esperado = 4.5M;
            var atual = _lancheServices.RetornaTodosLanchesProntos().Where(l => l.Nome == "X-Burger").FirstOrDefault();

            Assert.AreEqual(esperado, atual.Total);
        }

        [TestMethod]
        public void verifica_valor_x_egg()
        {
            var esperado = 5.3M;
            var atual = _lancheServices.RetornaTodosLanchesProntos().Where(l => l.Nome == "X-Egg").FirstOrDefault();

            Assert.AreEqual(esperado, atual.Total);
        }
        
        [TestMethod]
        public void verifica_valor_x_egg_bacon()
        {
            var esperado = 7.3M;
            var atual = _lancheServices.RetornaTodosLanchesProntos().Where(l => l.Nome == "X-Egg Bacon").FirstOrDefault();

            Assert.AreEqual(esperado, atual.Total);
        }

        [TestMethod]
        public void deve_ser_promocao_ligth()
        {           
            var alface = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.ALFACE.ToDescription());
            var carne = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.CARNE.ToDescription());
            var ovo = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.OVO.ToDescription());
            var queijo = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.QUEIJO.ToDescription());

            var esperado = (alface.Valor + carne.Valor + ovo.Valor + queijo.Valor);

            esperado = esperado - (esperado * (0.1M));

            var lstIngredientes = new List<Ingrediente>
            {
                alface,
                carne,
                ovo,
                queijo
            };

            var atual = _lancheServices.RetornaLancheCustomizado(lstIngredientes);

            Assert.AreEqual(esperado, atual.Total);
        }

        [TestMethod]
        public void nao_deve_ser_promocao_ligth()
        {
            var alface = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.ALFACE.ToDescription());
            var bacon = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.BACON.ToDescription());
            var carne = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.CARNE.ToDescription());
            var ovo = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.OVO.ToDescription());
            var queijo = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.QUEIJO.ToDescription());

            var esperado = (alface.Valor + carne.Valor + ovo.Valor + queijo.Valor + bacon.Valor);

            var lstIngredientes = new List<Ingrediente>
            {
                alface,
                bacon,
                carne,
                ovo,
                queijo
            };

            var atual = _lancheServices.RetornaLancheCustomizado(lstIngredientes);

            Assert.AreEqual(esperado, atual.Total);
        }

        [TestMethod]
        public void nao_deve_ser_promocao_ligth_sem_alface()
        {           
            var bacon = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.BACON.ToDescription());
            var carne = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.CARNE.ToDescription());
            var ovo = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.OVO.ToDescription());
            var queijo = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.QUEIJO.ToDescription());

            var esperado = (carne.Valor + ovo.Valor + queijo.Valor + bacon.Valor);

            var lstIngredientes = new List<Ingrediente>
            {              
                bacon,
                carne,
                ovo,
                queijo
            };

            var atual = _lancheServices.RetornaLancheCustomizado(lstIngredientes);

            Assert.AreEqual(esperado, atual.Total);
        }

        [TestMethod]
        public void muita_carne()
        {
            var carne1 = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.CARNE.ToDescription());
            var carne2 = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.CARNE.ToDescription());
            var carne3 = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.CARNE.ToDescription());

            var bacon = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.BACON.ToDescription());           
            var ovo = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.OVO.ToDescription());
            var queijo = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.QUEIJO.ToDescription());

            var esperado = (carne1.Valor + carne2.Valor + ovo.Valor + queijo.Valor + bacon.Valor);

            var lstIngredientes = new List<Ingrediente>
            {
                bacon,
                carne1,
                carne2,
                carne3,
                ovo,
                queijo
            };

            var atual = _lancheServices.RetornaLancheCustomizado(lstIngredientes);

            Assert.AreEqual(esperado, atual.Total);
        }

        [TestMethod]
        public void muito_queijo()
        {
            var queijo1 = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.QUEIJO.ToDescription());
            var queijo2 = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.QUEIJO.ToDescription());
            var queijo3 = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.QUEIJO.ToDescription());

            var bacon = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.BACON.ToDescription());
            var ovo = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.OVO.ToDescription());
            var queijo4 = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.QUEIJO.ToDescription());
            var queijo5 = _ingredientes.FirstOrDefault(i => i.Nome == IngredienteEnum.QUEIJO.ToDescription());          

            var esperado = (queijo1.Valor + queijo2.Valor + bacon.Valor + ovo.Valor + queijo4.Valor);

            var lstIngredientes = new List<Ingrediente>
            {
               queijo1,
               queijo2,
               queijo3,
               bacon,
               ovo,
               queijo4                    
            };

            var atual = _lancheServices.RetornaLancheCustomizado(lstIngredientes);

            Assert.AreEqual(esperado, atual.Total);
        }
    }
}
