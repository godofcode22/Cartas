using System;
using System.Collections.Generic;
using Cartas.Interfaces;
using Cartas.Clases;
class Program
{
    static void Main(string[] args)
    {
        string opcion = "";
        do
        {
            Console.Clear();
            Console.WriteLine("========= MESA DE OPERACIONES - EVALUACIÓN =========");
            Console.WriteLine("QUÉ DESEAS ENSAMBLAR?");

            Console.WriteLine("\n--- PRUEBAS DE MAZO ---");
            Console.WriteLine("1) Probar Mazo (Crear, Mostrar, Barajar)");

            Console.WriteLine("\n--- ENSAMBLAR BLACKJACK ---");
            Console.WriteLine("2) Escenario: Cauteloso DEBE PEDIR (recibe 15)");
            Console.WriteLine("3) Escenario: Cauteloso DEBE PLANTARSE (recibe 18)");

            Console.WriteLine("\n--- ENSAMBLAR UNO ---");
            Console.WriteLine("4) Escenario: Forzar P1 con siete '+4'");

            Console.WriteLine("\n--- SIMULACIÓN NORMAL (AUTOMÁTICA) ---");
            Console.WriteLine("5) Simular Blackjack (Normal)");
            Console.WriteLine("6) Simular UNO (Normal)");

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("7) Salir");
            Console.WriteLine();
            Console.Write("Elige una operación: ");
            opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    PruebaDeMazo();
                    break;
                case "2":
                    EnsamblarBlackjack_DebePedir();
                    break;
                case "3":
                    EnsamblarBlackjack_DebePlantarse();
                    break;
                case "4":
                    EnsamblarUNO_ForzarMasCuatro();
                    break;
                case "5":
                    SimularBlackjackNormal();
                    break;
                case "6":
                    SimularUNONormal();
                    break;
                case "7":
                    Console.WriteLine("\nSaliendo del programa...");
                    break;
                default:
                    Console.WriteLine("\nOpcion no valida.");
                    break;
            }

            if (opcion != "7")
            {
                Console.WriteLine("\nPresiona ENTER para volver al menú...");
                Console.ReadLine();
            }

        } while (opcion != "7");
    }

    private static void EnsamblarBlackjack_DebePedir()
    {
        Console.Clear();
        Console.WriteLine("--- Ensamblando: Cauteloso DEBE PEDIR ---");

        var jugadores = EscenariosEvaluacion.GetJugadores_BJ_Cauteloso();

        var mazoFijo = EscenariosEvaluacion.GetMazo_BJ_DebePedir();

        IJuego juego = new JuegoBlackjack(1, jugadores, mazoFijo);

        juego.Inicializar();
        juego.Jugar();
    }

    private static void EnsamblarBlackjack_DebePlantarse()
    {
        Console.Clear();
        Console.WriteLine("--- Ensamblando: Cauteloso DEBE PLANTARSE ---");

        var jugadores = EscenariosEvaluacion.GetJugadores_BJ_Cauteloso();
        var mazoFijo = EscenariosEvaluacion.GetMazo_BJ_DebePlantarse();

        IJuego juego = new JuegoBlackjack(1, jugadores, mazoFijo);

        juego.Inicializar();
        juego.Jugar();
    }

    private static void EnsamblarUNO_ForzarMasCuatro()
    {
        Console.Clear();
        Console.WriteLine("--- Ensamblando: UNO Puros +4 ---");

        var jugadores = EscenariosEvaluacion.GetJugadores_UNO_3Players();
        var mazoFijo = EscenariosEvaluacion.GetMazo_UNO_ForzarMasCuatro();

        IJuego juego = new JuegoUNO(jugadores, mazoFijo);

        juego.Inicializar();
        juego.Jugar();
    }

    private static void PruebaDeMazo()
    {
        Console.Clear();
        Console.WriteLine("--- Prueba de Creación y Barajado de Mazo ---");

        Console.WriteLine("\n[1.1] Creando Mazo de Blackjack (Ordenado)...");
        var mazoBJ = new Mazo(new GeneradorMazoBlackjack());
        mazoBJ.MostrarCartas(10);

        Console.WriteLine("\n[1.2] Barajando Mazo de Blackjack...");
        mazoBJ.Barajar();
        mazoBJ.MostrarCartas(10);
    }

    private static void SimularBlackjackNormal()
    {
        Console.Clear();
        Console.WriteLine("--- Simulación Normal Blackjack ---");
        var jugadoresSimBJ = new List<JugadorPrincipal>
            {
                new JugadorPrincipal("Jugador Cauteloso", new JugadorCauteloso(17)),
                new JugadorPrincipal("Jugador Temerario", new JugadorTemerario())
            };
        IJuego juegoBJ = new JuegoBlackjack(1, jugadoresSimBJ, null);
        juegoBJ.Inicializar();
        juegoBJ.Jugar();
    }

    private static void SimularUNONormal()
    {
        Console.Clear();
        Console.WriteLine("--- Simulación Normal UNO ---");
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
}