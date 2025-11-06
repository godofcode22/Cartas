using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class JugadorTemerario : IComportamientoJugador
    {
        public bool DebePedirCarta(int puntosActuales)
        {
            return puntosActuales < 21;
        }
    }
}