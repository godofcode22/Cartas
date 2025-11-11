using System;
using System.Collections.Generic;
using System.Linq;
using Cartas.Clases;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class JuegoUNO : IJuego
    {
        private List<JugadorUNO> jugadores;
        private Mazo mazo;
        private List<ICarta> pozo;
        private string colorActual;
        private int indiceJugadorActual;
        private int direccionJuego;
        private bool juegoTerminado;
        private string ganador;

        public JuegoUNO()
        {
        }

        public void Inicializar()
        {
            Console.WriteLine("=== Iniciando Juego de UNO ===");
            mazo = new Mazo(new GeneradorMazoUNO());
            mazo.Barajar();

            pozo = new List<ICarta>();
            jugadores = new List<JugadorUNO>
            {
              //faltan los jugadores
            };

            if (jugadores.Count == 0)
            {
                Console.WriteLine("ADVERTENCIA: No se han configurado jugadores en JuegoUNO.cs.");
                juegoTerminado = true;
                return; 
            }

            for (int i = 0; i < 7; i++)
            {
                foreach (var jugador in jugadores)
                {
                    jugador.AgregarCarta(mazo.RepartirCarta());
                }
            }

            ICarta primeraCarta;
            do
            {
                primeraCarta = mazo.RepartirCarta();
                if (((ICartaUNO)primeraCarta).Tipo == "+4" || ((ICartaUNO)primeraCarta).Tipo == "CambioColor")
                {
                    mazo = new Mazo(new GeneradorMazoUNO()); 
                    mazo.Barajar();
                    pozo.Add(mazo.RepartirCarta()); 
                    primeraCarta = pozo[0];
                    pozo.Clear();
                }

            } while (((ICartaUNO)primeraCarta).Tipo == "+4" || ((ICartaUNO)primeraCarta).Tipo == "CambioColor");
            
            pozo.Add(primeraCarta);
            colorActual = primeraCarta.Color;

            Console.WriteLine($"La primera carta en el pozo es: {primeraCarta.MostrarCarta()}");

            indiceJugadorActual = 0;
            direccionJuego = 1;
            juegoTerminado = false;
        }

        public void Jugar()
        {
            if (juegoTerminado) 
            {
                Console.WriteLine("El juego no se inicializó correctamente.");
                return;
            }

            while (!juegoTerminado)
            {
                JugadorUNO jugadorActual = jugadores[indiceJugadorActual];
                Console.WriteLine($"\n--- Turno de {jugadorActual.Nombre} ---");
                Console.WriteLine($"Color actual: {colorActual}");
                Console.WriteLine($"Carta en pozo: {pozo.Last().MostrarCarta()}");
                jugadorActual.MostrarMano();

                jugadorActual.JugarTurno(mazo, pozo, ref colorActual);

                if (jugadorActual.Mano.Cartas.Count == 0)
                {
                    juegoTerminado = true;
                    ganador = jugadorActual.Nombre;
                    continue; 
                }

                ICarta cartaJugada = pozo.Last();
                AplicarEfectos(cartaJugada as ICartaUNO);

                indiceJugadorActual += direccionJuego;

                if (indiceJugadorActual < 0)
                    indiceJugadorActual = jugadores.Count - 1;
                else if (indiceJugadorActual >= jugadores.Count)
                    indiceJugadorActual = 0;
            }

            MostrarResultados();
        }

        private void AplicarEfectos(ICartaUNO cartaJugada)
        {
            int proximoIndice = (indiceJugadorActual + direccionJuego);
            if (proximoIndice < 0) proximoIndice = jugadores.Count - 1;
            if (proximoIndice >= jugadores.Count) proximoIndice = 0;
            
            JugadorUNO proximoJugador = jugadores[proximoIndice];

            switch (cartaJugada.Tipo)
            {
                case "Reversa":
                    direccionJuego *= -1;
                    Console.WriteLine("¡Se invierte la dirección!");
                    break;

                case "Bloqueo":
                    Console.WriteLine($"¡{proximoJugador.Nombre} pierde el turno!");
                    indiceJugadorActual += direccionJuego;
                    break;

                case "+2":
                    Console.WriteLine($"¡{proximoJugador.Nombre} roba 2 cartas!");
                    proximoJugador.AgregarCarta(mazo.RepartirCarta());
                    proximoJugador.AgregarCarta(mazo.RepartirCarta());
                    indiceJugadorActual += direccionJuego;
                    break;

                case "+4":
                    Console.WriteLine($"¡{proximoJugador.Nombre} roba 4 cartas!");
                    proximoJugador.AgregarCarta(mazo.RepartirCarta());
                    proximoJugador.AgregarCarta(mazo.RepartirCarta());
                    proximoJugador.AgregarCarta(mazo.RepartirCarta());
                    proximoJugador.AgregarCarta(mazo.RepartirCarta());
                    indiceJugadorActual += direccionJuego;
                    break;
            }
        }

        public void MostrarResultados()
        {
            Console.WriteLine("\n===== ¡JUEGO TERMINADO! =====");
            Console.WriteLine($"El ganador es: {ganador}");
            Console.WriteLine("=============================");
        }
    }
}