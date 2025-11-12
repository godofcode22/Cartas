using System;
using System.Collections.Generic;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class Mazo
    {
        private List<ICarta> cartas;
        private Random random;

        public Mazo(IGeneradorDeMazo generador)
        {
            cartas = new List<ICarta>(generador.CrearCartas());
            random = new Random();
        }

        public Mazo(List<ICarta> cartasFijas)
        {
            cartas = new List<ICarta>(cartasFijas);
            random = new Random();
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

        public ICarta RepartirCarta()
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

        public void MostrarCartas(int cantidad)
        {
            Console.WriteLine($"Mostrando las primeras {cantidad} cartas del mazo:");
            for (int i = 0; i < cantidad && i < cartas.Count; i++)
            {
                Console.WriteLine($"- {cartas[i].MostrarCarta()}");
            }
        }
    }
}