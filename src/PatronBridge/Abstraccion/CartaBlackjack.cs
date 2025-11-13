public class CartaBlackjack : Carta
{
    public CartaBlackjack(string palo, ICartaImplementacion implementacion)
        : base(palo, implementacion)
    {
    }

    public override void Mostrar()
    {
        Console.WriteLine(ObtenerInformacion());
    }
}