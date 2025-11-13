public class EfectoCartaRevelada : CartaDecorador
{
    public EfectoCartaRevelada(Carta carta) : base(carta)
    {
    }

    public override string ObtenerInformacion()
    {
        return cartaDecorada.ObtenerInformacion() +
               "\n[CARTA REVELADA] ✓ Visible para todos los jugadores";
    }

    public override void Mostrar()
    {
        Console.WriteLine("┌─────────────────────────────────┐");
        base.Mostrar();
        Console.WriteLine("└─────────────────────────────────┘");
    }
}