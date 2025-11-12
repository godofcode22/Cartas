using System;
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
                Console.WriteLine("=== SIMULADOR DE JUEGOS ===");
                Console.WriteLine("1) Jugar UNO");
                Console.WriteLine("2) Jugar Blackjack");
                Console.WriteLine("3) Salir");
                Console.WriteLine();
                Console.Write("Elige una opcion: ");
                opcion = Console.ReadLine() ?? "";

                if (opcion == "1")
                {
                    EjecutarUNO();
                }
                else if (opcion == "2")
                {
                    EjecutarBlackjack();
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("\nSaliendo del programa");
                }
                else if (opcion == "4")
                {
                    Console.WriteLine("Crear mazos para pruebas");
                    Mazo MazoBJ = new Mazo(new GeneradorMazoBlackjack());
                    Mazo MazoUNO = new Mazo(new GeneradorMazoUNO());
                    Console.WriteLine($"primeras 10 cartas del mazo \n");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(MazoBJ.RepartirCarta().MostrarCarta());
                    }
                    List<ICarta> cartasSacadas = new List<ICarta>();
                    for (int i = 0; i < 10; i++)
                    {
                        var carta = MazoBJ.RepartirCarta();
                        cartasSacadas.Add(carta);
                        Console.WriteLine($"{carta.MostrarCarta()} carta sacada del mazo");
                    }
                    foreach (var carta in cartasSacadas)
                    {
                        MazoBJ.AgregarCarta(carta);
                        Console.WriteLine($"{carta.MostrarCarta()} carta devuelta al mazo");
                    }
                    MazoBJ.Barajar();
                    Console.WriteLine($"\nprimeras 10 cartas del mazo despues de devolverlas y barajar \n");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(MazoBJ.RepartirCarta().MostrarCarta());
                    }
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

        private static void EjecutarUNO()
        {
            Console.Clear();
            Console.WriteLine("=== JUEGO UNO ===\n");

            var juegoUno = new JuegoUNO();
            juegoUno.Inicializar();
            juegoUno.Jugar();

            Console.WriteLine("\n=== Fin del juego UNO ===");
        }

        private static void EjecutarBlackjack()
        {
            Console.Clear();
            Console.WriteLine("=== JUEGO BLACKJACK ===\n");

            var juegoBJ = new JuegoBlackjack(1);
            juegoBJ.Jugar();

            Console.WriteLine("\n=== Fin del juego BLACKJACK ===");
        }
    }
}

