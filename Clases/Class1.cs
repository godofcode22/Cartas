using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class Carta : ICarta
    {
        public string Figura { get; set; }
        public string Palo { get; set; }
        public string Color { get; set; }
        public int Valor { get; set; }

        public Carta(string figura, string palo, string color, int valor)
        {
            Figura = figura;
            Palo = palo;
            Color = color;
            Valor = valor;
        }

        public string MostrarCarta()
        {
            return $"{Figura} de {Palo} ({Color})";
        }
    }
}
