using System;
using System.Collections.Generic;
using Cartas.Interfaces;

namespace Cartas.Clases
{
    public class ComportamientoAleatorioUNO : IComportamientoJugadorUNO
    {
        private Random random = new Random();

        public ICarta ElegirCarta(Mano mano, ICartaUNO cartaPozo, string colorActual, int cartasSiguienteJugador)
        {
            var validas = new List<ICarta>();

            foreach (var c in mano.Cartas)
            {
                if (PuedeJugarCarta(c, cartaPozo, colorActual))
                    validas.Add(c);
            }

            if (validas.Count == 0) return null;

            int idx = random.Next(validas.Count);
            return validas[idx];
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
