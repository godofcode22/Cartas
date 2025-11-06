using System;
using System.Collections.Generic;

namespace Cartas.Clases
{
    public class JuegoBlackjack
    {
        private List<JugadorPrincipal> jugadores;
        private Dealer dealer;
        private Mazo mazo;
        private int rondas;

        public JuegoBlackjack(int rondas = 1)
        {
            this.rondas = rondas;
            mazo = new Mazo();
            mazo.Barajar();
            jugadores = new List<JugadorPrincipal>
            {
                new JugadorPrincipal("Jugador 1", new JugadorCauteloso(17)),
                new JugadorPrincipal("Jugador 2", new JugadorTemerario())
            };

            dealer = new Dealer();
        }
        public void Jugar()
        {
            for (int ronda = 1; ronda <= rondas; ronda++)
            {
                Console.WriteLine($"RONDA {ronda}");
                mazo.Barajar();
                RepartirCartasIniciales();
            }
        }
    }  
}