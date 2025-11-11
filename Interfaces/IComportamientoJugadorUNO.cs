using Cartas.Clases;
using Cartas.Interfaces;

namespace Cartas.Interfaces
{
    public interface IComportamientoJugadorUNO
    {
        ICarta ElegirCarta(Mano mano, ICarta cartaPozo, string colorActual);
        bool PuedeJugarCarta(ICarta carta, ICarta cartaPozo, string colorActual);
        string ElegirColor();
    }
}
