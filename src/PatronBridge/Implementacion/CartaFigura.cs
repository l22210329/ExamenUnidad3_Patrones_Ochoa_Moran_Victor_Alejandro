public class CartaFigura : ICartaImplementacion
{
    private string figura;

    public CartaFigura(string figura)
    {
        if (figura != "J" && figura != "Q" && figura != "K")
            throw new ArgumentException("La figura debe ser J, Q o K");
        
        this.figura = figura;
    }

    public string ObtenerTipo()
    {
        return "Figura";
    }

    public int CalcularValor(bool asComoOnce)
    {
        return 10;
    }

    public string ObtenerDescripcion()
    {
        string nombreFigura;

        if (figura == "J")
        {
            nombreFigura = "Jota";
        }
        else 
        {
        if (figura == "Q")
        {
            nombreFigura = "Reina";
        }
        else
        {
        nombreFigura = "Rey";
        }
    }
        return $"{nombreFigura} - Vale 10 puntos";
}

    public bool EsAs()
    {
        return false;
    }


}