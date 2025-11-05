using System;

namespace Cartas.Interfaces
{
    public interface ICarta
    {
        string Figura { get; }
        string Palo { get; }
        string Color { get; }
        int Valor { get; } 

        string MostrarCarta(); 
    }
}
