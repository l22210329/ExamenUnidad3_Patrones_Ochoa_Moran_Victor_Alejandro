public abstract class CartaDecorador : Carta
{
    protected Carta cartaDecorada;

    public CartaDecorador(Carta carta) 
        : base(carta.ObtenerPalo(), carta.ObtenerImplementacion())
    {
        this.cartaDecorada = carta;
    }

    public override void Mostrar()
    {
        cartaDecorada.Mostrar();
    }

    public override int ObtenerValor()
    {
        return cartaDecorada.ObtenerValor();
    }

    public override string ObtenerPalo()
    {
        return cartaDecorada.ObtenerPalo();
    }

    public override ICartaImplementacion ObtenerImplementacion()
    {
        return cartaDecorada.ObtenerImplementacion();
    }

    public override bool EsAs()
    {
        return cartaDecorada.EsAs();
    }

    public override void CambiarValorAs(bool comoOnce)
    {
        cartaDecorada.CambiarValorAs(comoOnce);
    }

    public override string ObtenerNombreCompleto()
    {
        return cartaDecorada.ObtenerNombreCompleto();
    }

    public override string ObtenerInformacion()
    {
        return cartaDecorada.ObtenerInformacion();
    }
}