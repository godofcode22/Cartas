using System;
using Cartas.Clases;

class ProyectoCartas
{
    static void Main()
    {
        Console.WriteLine("Simulacion de Blackjack\n");

        var juego = new JuegoBlackjack(rondas: 2);
        juego.Jugar();

        Console.WriteLine("\nFin de la simulacion");
    }
}
