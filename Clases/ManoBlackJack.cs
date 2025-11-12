using System;
using System.Collections.Generic;
using Cartas.Interfaces; 

namespace Cartas.Clases
{
    public class Mano
    {
        public List<ICarta> Cartas { get; private set; }

        public Mano()
        {
            Cartas = new List<ICarta>();
        }

        public void AgregarCarta(ICarta carta)
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

