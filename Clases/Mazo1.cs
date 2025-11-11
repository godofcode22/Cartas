using System;
using System.Collections.Generic;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class Mazo
    {
        private List<CartaBlackJack> cartas;
        private Random random;

        public Mazo(IGeneradorDeMazo generador)
        {
            cartas = new List<CartaBlackJack>();
            random = new Random();

            foreach (var carta in generador.CrearCartas())
            {
                if (carta is CartaBlackJack cartaBJ)
                    cartas.Add(cartaBJ);
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
        public CartaBlackJack RepartirCarta()
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
