using System.Collections.Generic;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class GeneradorMazoUNO : IGeneradorDeMazo
    {
        public List<ICarta> CrearCartas()
        {
            List<ICarta> cartas = new List<ICarta>();
            string[] colores = { "Rojo", "Azul", "Verde", "Amarillo" };

            foreach (var color in colores)
            {
                cartas.Add(new CartaUNO(color, "Numero", 0));

                for (int i = 1; i <= 9; i++)
                {
                    cartas.Add(new CartaUNO(color, "Numero", i));
                    cartas.Add(new CartaUNO(color, "Numero", i));
                }
            }
            string[] especiales = { "Bloqueo", "Reversa", "+2" };
            foreach (var color in colores)
            {
                foreach (var tipo in especiales)
                {
                    cartas.Add(new CartaUNO(color, tipo));
                    cartas.Add(new CartaUNO(color, tipo));
                }
            }

            for (int i = 0; i < 4; i++)
            {
                cartas.Add(new CartaUNO("", "CambioColor"));
                cartas.Add(new CartaUNO("", "+4"));
            }
            return cartas;
        }
    }
}
