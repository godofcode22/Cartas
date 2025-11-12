using System;
using System.Collections.Generic;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class ComportamientoCalculadorUNO : IComportamientoJugadorUNO
    {
        private Random random = new Random();

        public ICarta ElegirCarta(Mano mano, ICartaUNO cartaPozo, string colorActual, int cartasSiguienteJugador)
        {
            if (cartasSiguienteJugador == 1)
            {
                foreach (var c in mano.Cartas)
                {
                    if (c is ICartaUNO u && (u.Tipo == "+4" || u.Tipo == "+2" || u.Tipo == "Bloqueo") && PuedeJugarCarta(c, cartaPozo, colorActual))
                        return c;
                }
                return null;
            }
            ICarta? mejorNumero = null;
            int mayor = -1;
            foreach (var c in mano.Cartas)
            {
                if (c is ICartaUNO u && u.Tipo == "Numero" && PuedeJugarCarta(c, cartaPozo, colorActual))
                {
                    if (u.Valor > mayor)
                    {
                        mayor = u.Valor;
                        mejorNumero = c;
                    }
                }
            }
            if (mejorNumero != null) return mejorNumero;

            foreach (var c in mano.Cartas)
            {
                if (c is ICartaUNO u && u.Tipo != "Numero" && PuedeJugarCarta(c, cartaPozo, colorActual))
                    return c;
            }
            foreach (var c in mano.Cartas)
            {
                if (c is ICartaUNO u && (u.Tipo == "CambioColor" || u.Tipo == "+4") && PuedeJugarCarta(c, cartaPozo, colorActual))
                    return c;
            }
            return null;
        }

        public string ElegirColor()
        {
            string[] colores = { "Rojo", "Verde", "Azul", "Amarillo" };
            return colores[random.Next(colores.Length)];
        }

        public bool PuedeJugarCarta(ICarta cartaNueva, ICartaUNO cartaPozo, string colorActual)
        {
            if (cartaPozo == null) return true;
            if (!(cartaNueva is ICartaUNO nueva)) return false;

            if (string.IsNullOrEmpty(nueva.Color) && (nueva.Tipo == "CambioColor" || nueva.Tipo == "+4"))
                return true;

            if (!string.IsNullOrEmpty(nueva.Color) && nueva.Color == colorActual)
                return true;

            if (nueva.Tipo == "Numero" && cartaPozo.Tipo == "Numero" && nueva.Valor == cartaPozo.Valor)
                return true;

            if (nueva.Tipo != "Numero" && nueva.Tipo == cartaPozo.Tipo)
                return true;

            return false;
        }
    }
}
