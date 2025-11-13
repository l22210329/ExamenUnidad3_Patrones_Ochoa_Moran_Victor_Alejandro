public class Baraja
{
    private List<Carta> cartas;
    private Random random;

    public Baraja()
    {
        cartas = new List<Carta>();
        random = new Random();
        InicializarBaraja();
    }

    private void InicializarBaraja()
    {
        string[] palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };

        foreach (string palo in palos)
        {
            
            for (int i = 2; i <= 10; i++)
            {
                cartas.Add(new CartaBlackjack(palo, new CartaNumerica(i)));
            }

            
            cartas.Add(new CartaBlackjack(palo, new CartaFigura("J")));
            cartas.Add(new CartaBlackjack(palo, new CartaFigura("Q")));
            cartas.Add(new CartaBlackjack(palo, new CartaFigura("K")));

            
            cartas.Add(new CartaBlackjack(palo, new CartaAs()));
        }
    }

    public void Barajar()
    {
        for (int i = cartas.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            var temp = cartas[i];
            cartas[i] = cartas[j];
            cartas[j] = temp;
        }
    }

    public Carta RepartirCarta()
    {
        if (cartas.Count == 0)
        {
            Console.WriteLine(" La baraja se ha agotado, reiniciando...");
            InicializarBaraja();
            Barajar();
        }

        Carta carta = cartas[0];
        cartas.RemoveAt(0);
        return new EfectoCartaRevelada(carta);
    }
}