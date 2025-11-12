using System;
using System.Collections.Generic;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class JuegoUNO : IJuego
    {
        private List<JugadorUNO> jugadores;
        private Mazo mazo;
        private List<ICarta> cartasDescarte;
        private string colorActual;
        private int indiceJugadorActual;
        private int direccionJuego;
        private bool juegoTerminado;
        private string ganador;

        public void Inicializar()
        {
            Console.WriteLine("=== Iniciando Juego de UNO ===");
            mazo = new Mazo(new GeneradorMazoUNO());
            mazo.Barajar();

            cartasDescarte = new List<ICarta>();
            jugadores = new List<JugadorUNO>
            {
                new JugadorUNO("Jugador 1", new ComportamientoAleatorioUNO()),
                new JugadorUNO("Jugador 2", new ComportamientoCalculadorUNO()),
                new JugadorUNO("Jugador 3", new ComportamientoAleatorioUNO())
            };
            for (int i = 0; i < 7; i++)
            {
                foreach (var jugador in jugadores)
                {
                    jugador.AgregarCarta(mazo.RepartirCarta());
                }
            }
            ICarta primeraCarta = mazo.RepartirCarta();
            while (((ICartaUNO)primeraCarta).Tipo == "+4" || ((ICartaUNO)primeraCarta).Tipo == "CambioColor")
                primeraCarta = mazo.RepartirCarta();

            cartasDescarte.Add(primeraCarta);
            colorActual = ((ICartaUNO)primeraCarta).Color;

            Console.WriteLine($"La primera carta en la pila es: {primeraCarta.MostrarCarta()}");

            indiceJugadorActual = 0;
            direccionJuego = 1;
            juegoTerminado = false;
        }

        public void Jugar()
        {
            while (!juegoTerminado)
            {
                JugadorUNO jugadorActual = jugadores[indiceJugadorActual];
                Console.WriteLine($"\n--- Turno de {jugadorActual.Nombre} ---");
                Console.WriteLine($"Color actual: {colorActual}");
                Console.WriteLine($"Carta en descarte: {cartasDescarte[cartasDescarte.Count - 1].MostrarCarta()}");
                jugadorActual.MostrarMano();

                jugadorActual.JugarTurno(mazo, cartasDescarte, ref colorActual, ObtenerCartasSiguienteJugador());

                if (jugadorActual.Mano.Cartas.Count == 0)
                {
                    ganador = jugadorActual.Nombre;
                    juegoTerminado = true;
                    break;
                }

                AplicarEfectos((ICartaUNO)cartasDescarte[cartasDescarte.Count - 1]);
                AvanzarTurno();
            }
            MostrarResultados();
        }

        private int ObtenerCartasSiguienteJugador()
        {
            int siguiente = indiceJugadorActual + direccionJuego;
            if (siguiente < 0) siguiente = jugadores.Count - 1;
            if (siguiente >= jugadores.Count) siguiente = 0;
            return jugadores[siguiente].Mano.Cartas.Count;
        }

        private void AplicarEfectos(ICartaUNO carta)
        {
            int siguiente = indiceJugadorActual + direccionJuego;
            if (siguiente < 0) siguiente = jugadores.Count - 1;
            if (siguiente >= jugadores.Count) siguiente = 0;
            JugadorUNO siguienteJugador = jugadores[siguiente];

            switch (carta.Tipo)
            {
                case "Reversa":
                    direccionJuego *= -1;
                    Console.WriteLine("¡Dirección invertida!");
                    break;

                case "Bloqueo":
                    Console.WriteLine($"¡{siguienteJugador.Nombre} pierde su turno!");
                    AvanzarTurno();
                    break;

                case "+2":
                    Console.WriteLine($"¡{siguienteJugador.Nombre} roba 2 cartas!");
                    siguienteJugador.AgregarCarta(mazo.RepartirCarta());
                    siguienteJugador.AgregarCarta(mazo.RepartirCarta());
                    AvanzarTurno();
                    break;

                case "+4":
                    Console.WriteLine($"¡{siguienteJugador.Nombre} roba 4 cartas!");
                    for (int i = 0; i < 4; i++)
                        siguienteJugador.AgregarCarta(mazo.RepartirCarta());
                    AvanzarTurno();
                    break;
            }
        }

        private void AvanzarTurno()
        {
            indiceJugadorActual += direccionJuego;
            if (indiceJugadorActual < 0) indiceJugadorActual = jugadores.Count - 1;
            if (indiceJugadorActual >= jugadores.Count) indiceJugadorActual = 0;
        }

        public void MostrarResultados()
        {
            Console.WriteLine("\n===== JUEGO TERMINADO =====");
            Console.WriteLine($"El ganador es: {ganador}");
            Console.WriteLine("=============================");
        }
    }
}
