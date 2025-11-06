using System;
using System.Collections.Generic;

namespace Cartas.Clases
{
    public class Mano
    {
        public List<Carta> Cartas { get; private set; }

        public Mano()
        {
            Cartas = new List<CartaBlackJack>();
        }

        public void AgregarCarta(CartaBlackJack carta)
        {
            Cartas.Add(CartaBlackJack);
        }

        public void Limpiar()
        {
            Cartas.Clear();
        }

        public void MostrarMano()
        {
            foreach (var carta in Cartas)
            {
                Console.WriteLine($" - {carta.MostrarCarta()}");
            }
        }
    }
}
