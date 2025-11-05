using System;
using System.Collections.Generic;

namespace Cartas.Clases
{
    public class Mano
    {
        public List<Carta> Cartas { get; private set; }

        public Mano()
        {
            Cartas = new List<Carta>();
        }

        public void AgregarCarta(Carta carta)
        {
            Cartas.Add(carta);
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
