public class EfectoValidacionJugada : CartaDecorador
{
    private string estadoMano;

    public EfectoValidacionJugada(Carta carta, int totalMano) : base(carta)
    {
        DeterminarEstado(totalMano);
    }

    private void DeterminarEstado(int total)
    {
        if (total == 21)
            estadoMano = "¡BLACKJACK! ";
        else if (total > 21)
            estadoMano = "¡TE PASASTE! ";
        else if (total >= 17)
            estadoMano = "Mano fuerte ";
        else if (total >= 12)
            estadoMano = "Mano media ";
        else
            estadoMano = "Mano débil ";
    }

    public string ObtenerEstadoMano()
    {
        return estadoMano;
    }

    public override string ObtenerInformacion()
    {
        return cartaDecorada.ObtenerInformacion() + 
               $"\n[VALIDACIÓN] Estado de la mano: {estadoMano}";
    }
}