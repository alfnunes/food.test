using System.ComponentModel;

namespace domain.model.inmemory
{
    public class Ingrediente
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public enum IngredienteEnum
        {
            [Description("Alface")]
            ALFACE = 0,
            [Description("Bacon")]
            BACON = 1,
            [Description("Hambúrguer de carne")]
            CARNE = 2,
            [Description("Ovo")]
            OVO = 3,
            [Description("Queijo")]
            QUEIJO = 4
        }
    }
}
