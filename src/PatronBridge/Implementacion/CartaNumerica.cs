public class CartaNumerica : ICartaImplementacion
{
    private int valor;

    public CartaNumerica(int valor)
    {
        if (valor < 2 || valor > 10)
            throw new ArgumentException("Las cartas numéricas deben tener valor entre 2 y 10");
        
        this.valor = valor;
    }

    public string ObtenerTipo()
    {
        return "Numérica";
    }

    public int CalcularValor(bool asComoOnce)
    {
        return valor;
    }

    public string ObtenerDescripcion()
    {
        return $"Carta numérica con valor fijo de {valor}";
    }

    public bool EsAs()
    {
        return false;
    }
}