namespace Cartas.Interfaces
{
    public interface ICarta
    {
        string Color { get; }
        int Valor { get; }
        string MostrarCarta();
    }

    public interface ICartaBlackJack : ICarta
    {
        string Figura { get; }
        string Palo { get; }
    }
    
    public interface ICartaUNO : ICarta
    {
        string Tipo { get; }
    }
}