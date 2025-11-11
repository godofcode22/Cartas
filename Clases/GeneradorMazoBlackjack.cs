using System.Collections.Generic;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class GeneradorMazoBlackjack : IGeneradorDeMazo
    {
        public List<ICarta> CrearCartas()
        {
            var lista = new List<ICarta>();

            string[] palos = { "Corazones", "Diamantes", "Treboles", "Picas" };
            string[] colores = { "Rojo", "Negro" };
            string[] figuras = { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            foreach (var palo in palos)
            {
                string color = (palo == "Corazones" || palo == "Diamantes") ? colores[0] : colores[1];

                foreach (var figura in figuras)
                {
                    int valor;

                    if (int.TryParse(figura, out valor))
                        valor = int.Parse(figura);
                    else if (figura == "As")
                        valor = 11;
                    else
                        valor = 10;
                    lista.Add(new CartaBlackJack(figura, palo, color, valor));
                }
            }
            return lista;
        }
    }
}
