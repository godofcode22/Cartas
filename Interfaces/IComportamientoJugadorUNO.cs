using Cartas.Clases;
using Cartas.Interfaces;

namespace Cartas.Interfaces
{
    public interface IComportamientoJugadorUNO
    {
        ICarta ElegirCarta(Mano mano, ICartaUNO cartaPozo, string colorActual, int CartasSiguienteJugador);
        bool PuedeJugarCarta(ICarta carta, ICartaUNO cartaPozo, string colorActual);
        string ElegirColor();
    }
}
