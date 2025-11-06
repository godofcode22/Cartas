using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class JugadorCauteloso : IComportamientoJugador
    {
        private int limitePuntos;

        public JugadorCauteloso(int limite)
        {
            limitePuntos = limite;
        }
        public bool DebePedirCarta(int puntosActuales)
        {
            return puntosActuales < limitePuntos;
        }
    }
}