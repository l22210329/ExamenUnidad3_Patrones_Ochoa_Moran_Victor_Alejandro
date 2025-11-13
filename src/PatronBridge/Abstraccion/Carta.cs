public abstract class Carta
{
    protected ICartaImplementacion implementacion;
    protected string palo;
    protected bool asComoOnce;

    public Carta(string palo, ICartaImplementacion implementacion)
    {
        this.palo = palo;
        this.implementacion = implementacion;
        this.asComoOnce = true;
    }

    public abstract void Mostrar();
    
    public virtual int ObtenerValor()
    {
        return implementacion.CalcularValor(asComoOnce);
    }

    public virtual string ObtenerPalo()
    {
        return palo;
    }

    public virtual ICartaImplementacion ObtenerImplementacion()
    {
        return implementacion;
    }

    public virtual bool EsAs()
    {
        return implementacion.EsAs();
    }

    public virtual void CambiarValorAs(bool comoOnce)
    {
        if (EsAs())
        {
            asComoOnce = comoOnce;
        }
    }

    public virtual string ObtenerNombreCompleto()
    {
        string nombre = "";
        
        if (implementacion is CartaNumerica)
        {
            nombre = implementacion.CalcularValor(true).ToString();
        }
        else if (implementacion is CartaFigura)
        {
            int valor = implementacion.CalcularValor(true);
            if (valor == 10)
            {
                nombre = implementacion.ObtenerTipo() == "Figura" ? "J/Q/K" : "10";

                string desc = implementacion.ObtenerDescripcion();
                if (desc.Contains("Jota")) nombre = "J";
                else if (desc.Contains("Reina")) nombre = "Q";
                else if (desc.Contains("Rey")) nombre = "K";
            }
        }
        else if (implementacion is CartaAs)
        {
            nombre = "A";
        }

        return $"{nombre} de {palo}";
    }

    public virtual string ObtenerInformacion()
    {
        return $"Carta: {ObtenerNombreCompleto()}\n" +
               $"Tipo: {implementacion.ObtenerTipo()}\n" +
               $"Valor actual: {ObtenerValor()} puntos\n" +
               $"Descripción: {implementacion.ObtenerDescripcion()}";
    }
}