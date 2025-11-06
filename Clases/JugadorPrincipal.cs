using System;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class JugadorPrincipal
    {
        public string Nombre { get; private set; }
        public Mano Mano { get; private set; }
        private IComportamientoJugador comportamiento; 
        private CalculadorPuntosBlackjack calculador; 

        public JugadorPrincipal(string nombre, IComportamientoJugador comportamiento)
        {
            Nombre = nombre;
            Mano = new Mano();
            this.comportamiento = comportamiento;
            this.calculador = new CalculadorPuntosBlackjack();
        }

        public void AgregarCarta(CartaBlackJack carta)
        {
            Mano.AgregarCarta(carta);
        }

        public int CalcularPuntos()
        {
            return calculador.CalcularPuntos(Mano);
        }

        public void MostrarMano()
        {
            Console.WriteLine($"{Nombre} tiene:");
            Mano.MostrarMano();
            Console.WriteLine($"Total: {CalcularPuntos()} puntos");
        }

        public void JugarTurno(Mazo mazo)
        {
            Console.WriteLine($"Turno de {Nombre}");
            MostrarMano();

            while (comportamiento.DebePedirCarta(CalcularPuntos()))
            {
                if (mazo.CartasRestantes() == 0)
                {
                    Console.WriteLine("El mazo está vacio.");
                    break;
                }

                var carta = mazo.RepartirCarta();
                AgregarCarta(carta);
                Console.WriteLine($"{Nombre} pide carta: {carta.MostrarCarta()}");

                if (CalcularPuntos() > 21)
                {
                    Console.WriteLine($"{Nombre} se paso de 21 puntos.");
                    break;
                }
            }

            Console.WriteLine($"{Nombre} termina turno con {CalcularPuntos()} puntos.");
        }

        public void LimpiarMano()
        {
            Mano.Limpiar();
        }
    }
}
