public class CartaAs : ICartaImplementacion
{
    public string ObtenerTipo()
    {
        return "As";
    }

    public int CalcularValor(bool asComoOnce)
    {
        
        if (asComoOnce == true)
        {
            return 11;
        }
        else
        {
            return 1;
        }
        
    }

    public string ObtenerDescripcion()
    {
        return "As - Puede valer 1 u 11 puntos según convenga";
    }

    public bool EsAs()
    {
        return true;
    }
}