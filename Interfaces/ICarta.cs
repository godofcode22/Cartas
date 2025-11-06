using System;

namespace Cartas.Interfaces
{
    public interface ICartaBlackJack
    {
        string Figura { get; }
        string Palo { get; }
        string Color { get; }
        int Valor { get; }

        string MostrarCarta();
    }
    public interface ICartaUNO
    {
        string Color { get; }
        string Tipo { get; }
        int Valor { get; }

        string MostrarCarta();
    }
    public interface ICarta
    {
      
        string Color { get; }
        int Valor { get; }

        string MostrarCarta();
    }
}
