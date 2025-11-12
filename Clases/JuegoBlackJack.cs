using System;
using System.Collections.Generic;
using Cartas.Interfaces;
namespace Cartas.Clases
{
    public class JuegoBlackjack : IJuego 
    {
        private List<JugadorPrincipal> jugadores;
        private Dealer dealer;
        private Mazo mazo;
        private int rondas;

        public JuegoBlackjack(int rondas, List<JugadorPrincipal> jugadores, List<ICarta> mazoFijo = null)
        {
            this.rondas = rondas;
            this.jugadores = jugadores; 
            this.dealer = new Dealer();

            if (mazoFijo != null)
            {
                Console.WriteLine("=== INICIANDO CON MAZO FIJO (MODO EVALUACIÓN) ===");
                mazo = new Mazo(mazoFijo);
            }
            else
            {
                mazo = new Mazo(new GeneradorMazoBlackjack());
                mazo.Barajar();
            }
        }

        public void Inicializar()
        {
             Console.WriteLine("Juego de Blackjack inicializado.");
        }

        public void Jugar()
        {
            for (int ronda = 1; ronda <= rondas; ronda++)
            {
                Console.WriteLine($"\n===== RONDA {ronda} =====");

                if (mazo.CartasRestantes() < (2 * (jugadores.Count + 1)))
                {
                    Console.WriteLine("Re-barajando mazo estándar...");
                    mazo = new Mazo(new GeneradorMazoBlackjack());
                    mazo.Barajar();
                }

                RepartirCartasIniciales();
                MostrarEstadoInicial();

                foreach (var jugador in jugadores)
                {
                    jugador.JugarTurno(mazo);
                }
                dealer.JugarTurno(mazo);

                DeterminarGanadores();
                LimpiarManos();
            }
            MostrarResultados();
        }
        
        public void MostrarResultados()
        {
             Console.WriteLine("\n===== Fin de la partida de Blackjack =====\n");
        }

        private void RepartirCartasIniciales()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var jugador in jugadores)
                    jugador.AgregarCarta(mazo.RepartirCarta()); 
                    dealer.AgregarCarta(mazo.RepartirCarta());
            }
        }

        private void MostrarEstadoInicial()
        {
            Console.WriteLine("\nCartas iniciales:");
            foreach (var jugador in jugadores)
                jugador.MostrarMano();

            Console.WriteLine($"Dealer muestra una carta: {dealer.Mano.Cartas[0].MostrarCarta()}\n");
        }
        
        private void DeterminarGanadores()
        {
            int puntosDealer = dealer.CalcularPuntos();
            Console.WriteLine($"Dealer termina con {puntosDealer} puntos.\n");

            if (puntosDealer > 21)
            {
                Console.WriteLine("El dealer se paso de 21. Ganan todos los que no se pasaron.\n");

                foreach (var jugador in jugadores)
                {
                    int puntos = jugador.CalcularPuntos();
                    if (puntos <= 21)
                        Console.WriteLine($"{jugador.Nombre} gana con {puntos} puntos.");
                    else
                        Console.WriteLine($"{jugador.Nombre} se paso con {puntos} puntos.");
                }
            }
            else
            {
                foreach (var jugador in jugadores)
                {
                    int puntos = jugador.CalcularPuntos();

                    if (puntos > 21)
                        Console.WriteLine($"{jugador.Nombre} pierde (se paso con {puntos}).");
                    else if (puntos > puntosDealer)
                        Console.WriteLine($"{jugador.Nombre} gana con {puntos} puntos (dealer tenia {puntosDealer}).");
                    else if (puntos == puntosDealer)
                        Console.WriteLine($"{jugador.Nombre} empata con el dealer ({puntos}).");
                    else
                        Console.WriteLine($"{jugador.Nombre} pierde ({puntos} vs dealer {puntosDealer}).");
                }
            }

            Console.WriteLine("\n===== Fin de la ronda =====\n");
        }
        
        private void LimpiarManos()
        {
            foreach (var jugador in jugadores)
                jugador.LimpiarMano();
            dealer.LimpiarMano();
        }
    }
}