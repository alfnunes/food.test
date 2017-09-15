using domain.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using static domain.model.inmemory.Ingrediente;

namespace domain.model.inmemory
{
    public class Lanche
    {
        public string Nome { get; set; }
        public IEnumerable<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

        private decimal _total;

        public decimal Total
        {
            get { return _total; }
            set
            {
                var light = Ingredientes.Any(i => i.Nome.Equals(IngredienteEnum.ALFACE.ToDescription())) && 
                    !Ingredientes.Any(i => i.Nome.Equals(IngredienteEnum.BACON.ToDescription()));

                if (light)
                    _total = value - (value * (0.1M));
                else
                    _total = value;

                VerificaDescontoIngrediente(IngredienteEnum.CARNE);
                VerificaDescontoIngrediente(IngredienteEnum.QUEIJO);

            }
        }

        /// <summary>
        /// Verifica a promoção de grande quantidade de determinada porção
        /// </summary>
        /// <param name="ingrediente"></param>
        private void VerificaDescontoIngrediente(IngredienteEnum ingrediente)
        {
            var total = Ingredientes.Count(i => i.Nome == ingrediente.ToDescription());          
            var qtdeDesconto = (total/3);

            if (qtdeDesconto > 0)
            {
                var valor = Ingredientes.FirstOrDefault(i => i.Nome == ingrediente.ToDescription()).Valor;
                _total -= (qtdeDesconto * valor);
            }
        }      
    }
}
