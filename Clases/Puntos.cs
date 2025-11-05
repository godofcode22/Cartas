using System.Linq;

namespace Cartas.Clases
{
    public class CalculadorPuntosBlackjack
    {
        public int CalcularPuntos(Mano mano)
        {
            int total = 0;
            int ases = 0;

            foreach (var carta in mano.Cartas)
            {
                if (carta.Figura == "As")
                {
                    ases++;
                    total += 11;
                }
                else
                {
                    total += carta.Valor;
                }
            }
            while (total > 21 && ases > 0)
            {
                total -= 10;
                ases--;
            }
            return total;
        }
    }
}
