using System;
using Cartas.Clases;

class ProyectoCartas
{
    static void Main()
    {
        var mazo = new Mazo();
        mazo.Barajar();

        var manoJugador = new Mano();

        for (int i = 0; i < 2; i++)
        {
            var carta = mazo.RepartirCarta();
            manoJugador.AgregarCarta(carta);
            Console.WriteLine($"Carta {i + 1}: {carta.MostrarCarta()}");
        }
        var calculador = new CalculadorPuntosBlackjack();
        int puntos = calculador.CalcularPuntos(manoJugador);

        Console.WriteLine($"Puntos del jugador: {puntos}");
        Console.WriteLine($"Cartas restantes en el mazo: {mazo.CartasRestantes()}");
    }
}
