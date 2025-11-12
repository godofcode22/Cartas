using System;
using System.Collections.Generic;
using Cartas.Clases;
using Cartas.Interfaces;

namespace Cartas
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcion = "";
            do
            {
                Console.Clear();
                Console.WriteLine("=== EVALUACIÓN PROYECTO CARTAS ===");
                Console.WriteLine("1) Modo Simulación (Juegos normales)");
                Console.WriteLine("2) Modo Evaluación (Pruebas específicas)");
                Console.WriteLine("3) Salir");
                Console.WriteLine();
                Console.Write("Elige una opcion: ");
                opcion = Console.ReadLine() ?? "";

                if (opcion == "1")
                {
                    EjecutarSimulacion();
                }
                else if (opcion == "2")
                {
                    EjecutarEvaluacion();
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("\nSaliendo del programa");
                }
                else
                {
                    Console.WriteLine("\nOpcion no valida, intenta de nuevo");
                }
                if (opcion != "3")
                {
                    Console.WriteLine("\nPresiona ENTER para continuar");
                    Console.ReadLine();
                }

            } while (opcion != "3");
        }

        private static void EjecutarSimulacion()
        {
            Console.Clear();
            Console.WriteLine("=== MODO SIMULACIÓN ===\n");
            
            Console.WriteLine("--- Ejecutando Blackjack (Simulación) ---");
            var jugadoresSimBJ = new List<JugadorPrincipal>
            {
                new JugadorPrincipal("Jugador Cauteloso", new JugadorCauteloso(17)),
                new JugadorPrincipal("Jugador Temerario", new JugadorTemerario())
            };
            IJuego juegoBJ = new JuegoBlackjack(1, jugadoresSimBJ, null); 
            juegoBJ.Inicializar();
            juegoBJ.Jugar();

            Console.WriteLine("\nPresiona ENTER para la simulación de UNO");
            Console.ReadLine();

            Console.WriteLine("--- Ejecutando UNO (Simulación) ---");
            var jugadoresSimUNO = new List<JugadorUNO>
            {
                new JugadorUNO("CPU Aleatorio 1", new ComportamientoAleatorioUNO()),
                new JugadorUNO("CPU Calculador", new ComportamientoCalculadorUNO()),
                new JugadorUNO("CPU Aleatorio 2", new ComportamientoAleatorioUNO())
            };
            IJuego juegoUno = new JuegoUNO(jugadoresSimUNO, null); 
            juegoUno.Inicializar();
            juegoUno.Jugar();
        }

        private static void EjecutarEvaluacion()
        {
            Console.Clear();
            Console.WriteLine("=== MODO EVALUACIÓN ===");

            PruebaDeMazo();
            Console.WriteLine("\nPresiona ENTER para la prueba de Blackjack Fijo");
            Console.ReadLine();

            PruebaBlackjackFijo();
            Console.WriteLine("\nPresiona ENTER para la prueba de UNO Fijo");
            Console.ReadLine();
            
            PruebaUNOFijo();
        }

        private static void PruebaDeMazo()
        {
            Console.Clear();
            Console.WriteLine("--- Prueba de Creación y Barajado de Mazo ---");
            
            Console.WriteLine("\n[Prueba 1: Mazo de Blackjack ordenado]");
            var mazoOrdenado = new Mazo(new GeneradorMazoBlackjack());
            mazoOrdenado.MostrarCartas(10);

            Console.WriteLine("\n[Prueba 2: Mazo de Blackjack barajado]");
            mazoOrdenado.Barajar();
            mazoOrdenado.MostrarCartas(10);

            Console.WriteLine("\n[Prueba 3: Mazo de UNO ordenado]");
            var mazoUno = new Mazo(new GeneradorMazoUNO());
            mazoUno.MostrarCartas(10);
            
            Console.WriteLine("\n[Prueba 4: Mazo de UNO barajado]");
            mazoUno.Barajar();
            mazoUno.MostrarCartas(10);
        }

        private static void PruebaBlackjackFijo()
        {
            Console.Clear();
            Console.WriteLine("--- Prueba de Blackjack con Mazo Fijo ---");
            Console.WriteLine("Escenario: El jugador se planta (20), el Dealer se pasa.\n");

            var jugadores = new List<JugadorPrincipal>
            {
                new JugadorPrincipal("Jugador Cauteloso (Prueba)", new JugadorCauteloso(17))
            };

            var mazoFijo = new List<ICarta>
            {
                new CartaBlackJack("10", "Picas", "Negro", 10),    
                new CartaBlackJack("5", "Treboles", "Negro", 5), 
                new CartaBlackJack("As", "Corazones", "Rojo", 11), 
                new CartaBlackJack("10", "Diamantes", "Rojo", 10),
                new CartaBlackJack("8", "Picas", "Negro", 8)      
            };
            
            mazoFijo.Reverse(); 

            IJuego juegoBJFijo = new JuegoBlackjack(1, jugadores, mazoFijo);
            juegoBJFijo.Inicializar();
            juegoBJFijo.Jugar();
        }

        private static void PruebaUNOFijo()
        {
            Console.Clear();
            Console.WriteLine("--- Prueba de UNO con Mazo Fijo ---");
            Console.WriteLine("Escenario: Jugador 1 (Aleatorio) recibe puros +4.\n");

            var jugadores = new List<JugadorUNO>
            {
                new JugadorUNO("Jugador 1 (+4)", new ComportamientoAleatorioUNO()),
                new JugadorUNO("Jugador 2 (Víctima)", new ComportamientoCalculadorUNO())
            };

            var mazoFijo = new List<ICarta>();
            
            for(int i = 0; i < 7; i++)
                mazoFijo.Add(new CartaUNO("", "+4")); 
            
            for(int i = 0; i < 7; i++)
                mazoFijo.Add(new CartaUNO("Rojo", "Numero", i)); 
            
            mazoFijo.Add(new CartaUNO("Azul", "Numero", 5));
            
            mazoFijo.Add(new CartaUNO("Verde", "Numero", 1));
            mazoFijo.Add(new CartaUNO("Amarillo", "Numero", 2));
            
            mazoFijo.Reverse();
            
            IJuego juegoUNOFijo = new JuegoUNO(jugadores, mazoFijo);
            juegoUNOFijo.Inicializar(); 
            juegoUNOFijo.Jugar();
        }
    }
}
