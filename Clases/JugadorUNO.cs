using System;
using System.Collections.Generic;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class JugadorUNO
    {
        public string Nombre { get; private set; }
        public Mano Mano { get; private set; }
        private IComportamientoJugadorUNO comportamiento;

        public JugadorUNO(string nombre, IComportamientoJugadorUNO comportamiento)
        {
            Nombre = nombre;
            this.comportamiento = comportamiento;
            Mano = new Mano();
        }

        public void AgregarCarta(ICarta carta)
        {
            Mano.AgregarCarta(carta);
        }

        public void MostrarMano()
        {
            Console.WriteLine($"\n{Nombre} tiene:");
            Mano.MostrarMano();
        }

        public bool JugarTurno(Mazo mazo, List<ICarta> pozo, ref string colorActual, int cartasSiguienteJugador)
        {
            ICartaUNO? cartaPozo = null;
            if (pozo.Count > 0)
                cartaPozo = (ICartaUNO)pozo[pozo.Count - 1];

            ICarta cartaElegida = comportamiento.ElegirCarta(Mano, cartaPozo, colorActual, cartasSiguienteJugador);

            if (cartaElegida != null)
            {
                Mano.Cartas.Remove(cartaElegida);
                pozo.Add(cartaElegida);

                var cartaUNO = (ICartaUNO)cartaElegida;

                if (cartaUNO.Color == "" && (cartaUNO.Tipo == "CambioColor" || cartaUNO.Tipo == "+4"))
                {
                    colorActual = comportamiento.ElegirColor();
                    Console.WriteLine($"{Nombre} cambia el color a {colorActual}");
                }
                else
                {
                    colorActual = cartaUNO.Color;
                }

                Console.WriteLine($"{Nombre} juega: {cartaUNO.MostrarCarta()}");

                if (Mano.Cartas.Count == 1)
                    Console.WriteLine($"{Nombre}: ¡UNO!");

                return true;
            }
            else
            {
                ICarta nueva = mazo.RepartirCarta();
                Mano.AgregarCarta(nueva);
                Console.WriteLine($"{Nombre} roba una carta ({nueva.MostrarCarta()})");

                if (comportamiento.PuedeJugarCarta(nueva, cartaPozo, colorActual))
                {
                    Mano.Cartas.Remove(nueva);
                    pozo.Add(nueva);
                    Console.WriteLine($"{Nombre} juega la carta recien robada: {nueva.MostrarCarta()}");

                    var cartaUNO = (ICartaUNO)nueva;
                    if (cartaUNO.Color == "" && (cartaUNO.Tipo == "CambioColor" || cartaUNO.Tipo == "+4"))
                    {
                        colorActual = comportamiento.ElegirColor();
                        Console.WriteLine($"{Nombre} cambia el color a {colorActual}");
                    }
                    else
                    {
                        colorActual = cartaUNO.Color;
                    }
                }
                return false;
            }
        }
    }
}

