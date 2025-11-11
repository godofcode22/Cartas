using System;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class CartaUNO : ICartaUNO
    {
        public string Color { get; private set; }
        public string Tipo { get; private set; }  
        public int Valor { get; private set; }

        public CartaUNO(string color, string tipo, int valor = -1)
        {
            Color = color;
            Tipo = tipo;
            Valor = valor;
        }

        public string MostrarCarta()
        {
            if (Tipo == "Numero")
                return $"{Color} {Valor}";
            else if (Color == "")
                return $"{Tipo} (Comodin)";
            else
                return $"{Color} {Tipo}";
        }
    }
}
