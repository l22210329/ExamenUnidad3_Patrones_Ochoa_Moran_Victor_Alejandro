public class EfectoConteoCartas : CartaDecorador
{
    private int valorConteo;

    public EfectoConteoCartas(Carta carta) : base(carta)
    {
        
        int valor = carta.ObtenerValor();
        
        if (valor >= 2 && valor <= 6)
            valorConteo = +1;
        else if (valor >= 10 || carta.EsAs())
            valorConteo = -1;
        else
            valorConteo = 0;
    }

    public int ObtenerValorConteo()
    {
        return valorConteo;
    }

    public override string ObtenerInformacion()
    {
        string signo = valorConteo > 0 ? "+" : "";
        string categoria = "";
        
        if (valorConteo > 0)
            categoria = "BAJA (favorece al jugador)";
        else if (valorConteo < 0)
            categoria = "ALTA (favorece a la casa)";
        else
            categoria = "NEUTRA";

        return cartaDecorada.ObtenerInformacion() +
            $"\n[CONTEO DE CARTAS] Valor: {signo}{valorConteo} | Categoría: {categoria}";
    }
}