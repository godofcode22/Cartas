using System;

namespace Cartas.Clases
{
    public class Dealer : JugadorPrincipal
    {
        public Dealer() : base("Dealer", new ComportamientoDealer()) { }
    }
  
    public class ComportamientoDealer : Interfaces.IComportamientoJugador
    {
        public bool DebePedirCarta(int puntosActuales)
        {
            return puntosActuales < 17;
        }
    }
}
