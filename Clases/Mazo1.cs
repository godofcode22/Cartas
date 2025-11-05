using System;
using System.Collections.Generic;

namespace Cartas.Clases
{
    public class Mazo
    {
        private List<Carta> cartas;
        private Random random;

        public Mazo()
        {
            cartas = new List<Carta>();
            random = new Random();
            CrearMazo();
        }

        private void CrearMazo()
        {
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

                    cartas.Add(new Carta(figura, palo, color, valor));
                }
            }
        }

        public void Barajar()
        {
            for (int i = 0; i < cartas.Count; i++)
            {
                int j = random.Next(cartas.Count);
                var temp = cartas[i];
                cartas[i] = cartas[j];
                cartas[j] = temp;
            }
        }

        public Carta RepartirCarta()
        {
            if (cartas.Count == 0)
                throw new InvalidOperationException("No hay mas cartas en el mazo.");

            var carta = cartas[0];
            cartas.RemoveAt(0);
            return carta;
        }

        public int CartasRestantes()
        {
            return cartas.Count;
        }
    }
}
