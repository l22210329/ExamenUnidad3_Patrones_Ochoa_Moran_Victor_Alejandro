public class Mano
{
    private List<Carta> cartas;
    private string propietario;

    public Mano(string propietario)
    {
        this.propietario = propietario;
        this.cartas = new List<Carta>();
    }

    public void AgregarCarta(Carta carta)
    {
        cartas.Add(carta);
    }

    public int CalcularTotal()
    {
        int total = 0;
        int ases = 0;

        foreach (var carta in cartas)
        {
            total += carta.ObtenerValor();
            if (carta.EsAs())
                ases++;
        }

        while (total > 21 && ases > 0)
        {
            total -= 10;
            ases--;
        }

        return total;
    }

    public void MostrarMano(bool ocultarPrimera = false)
    {
        Console.WriteLine($"\n═══ Mano de {propietario} ═══");
        
        for (int i = 0; i < cartas.Count; i++)
        {
            if (i == 0 && ocultarPrimera)
            {
                Console.WriteLine("\n[CARTA OCULTA] 🎴");
            }
            else
            {
                Console.WriteLine();
                cartas[i].Mostrar();
            }
        }

        if (!ocultarPrimera)
        {
            Console.WriteLine($"\n Total: {CalcularTotal()} puntos");
        }
        
        Console.WriteLine(new string('═', 40));
    }

    public List<Carta> ObtenerCartas()
    {
        return cartas;
    }

    public bool TieneBlackjack()
    {
        return cartas.Count == 2 && CalcularTotal() == 21;
    }
}