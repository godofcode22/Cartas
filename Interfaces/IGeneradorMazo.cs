using System.Collections.Generic;

namespace Cartas.Interfaces
{
    public interface IGeneradorDeMazo
    {
        List<ICarta> CrearCartas();
    }
}
