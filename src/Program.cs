class Program
{
    static Baraja baraja;
    static int conteoTotal = 0;

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        bool jugarOtraVez = true;

        while (jugarOtraVez)
        {
            MostrarMenuPrincipal();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    JugarBlackjack();
                    break;
                case "2":
                    Console.WriteLine("\n ¡Gracias por jugar! ¡Hasta pronto!");
                    jugarOtraVez = false;
                    break;
                default:
                    Console.WriteLine("\n Opción inválida. Intenta de nuevo.");
                    break;
            }
        }
    }

    static void MostrarMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║      BLACKJACK - PATRONES BRIDGE Y DECORATOR          ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");
        Console.WriteLine("Selecciona una opción:\n");
        Console.WriteLine("  1)  Jugar Blackjack");
        Console.WriteLine("  2)  Salir\n");
        Console.Write(" Tu elección: ");
    }


    static void JugarBlackjack()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║               PARTIDA DE BLACKJACK                     ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

        baraja = new Baraja();
        baraja.Barajar();
        conteoTotal = 0;

        Mano manoJugador = new Mano("JUGADOR");
        Mano manoCrupier = new Mano("CRUPIER");

        Console.WriteLine("🎴 Repartiendo cartas...\n");
        System.Threading.Thread.Sleep(1000);

        manoJugador.AgregarCarta(baraja.RepartirCarta());
        manoCrupier.AgregarCarta(baraja.RepartirCarta());
        manoJugador.AgregarCarta(baraja.RepartirCarta());
        manoCrupier.AgregarCarta(baraja.RepartirCarta());

        manoJugador.MostrarMano();
        manoCrupier.MostrarMano(true); 

        if (manoJugador.TieneBlackjack())
        {
            Console.WriteLine("\n ¡BLACKJACK! ");
            manoCrupier.MostrarMano(); 
            
            if (manoCrupier.TieneBlackjack())
            {
                Console.WriteLine("\n ¡EMPATE! El crupier también tiene Blackjack.");
            }
            else
            {
                Console.WriteLine("\n ¡GANASTE! Blackjack natural.");
            }
            
            Console.WriteLine("\n Presiona cualquier tecla para volver al menú...");
            Console.ReadKey();
            return;
        }

        
        bool sePlanto = false;
        while (!sePlanto && manoJugador.CalcularTotal() < 21)
        {
            Console.WriteLine("\n" + new string('─', 55));
            Console.WriteLine("¿Qué deseas hacer?");
            Console.WriteLine("  [C] Pedir Carta");
            Console.WriteLine("  [P] Plantarse");
            Console.Write("\n  Tu elección: ");
            
            string eleccion = Console.ReadLine().ToUpper();

            if (eleccion == "C")
            {
                Console.WriteLine("\n🎴 Pidiendo carta...\n");
                System.Threading.Thread.Sleep(800);
                
                Carta nuevaCarta = baraja.RepartirCarta();
                manoJugador.AgregarCarta(nuevaCarta);
                
                manoJugador.MostrarMano();
                
                if (manoJugador.CalcularTotal() > 21)
                {
                    Console.WriteLine("\n ¡TE PASASTE DE 21! Has perdido.");
                    Console.WriteLine("\n Presiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    return;
                }
            }
            else if (eleccion == "P")
            {
                sePlanto = true;
                Console.WriteLine("\n Te has plantado con " + manoJugador.CalcularTotal() + " puntos.");
            }
            else
            {
                Console.WriteLine("\n Opción inválida. Usa C o P.");
            }
        }

       
        Console.WriteLine("\n" + new string('═', 55));
        Console.WriteLine(" Turno del crupier...\n");
        System.Threading.Thread.Sleep(1500);
        
        manoCrupier.MostrarMano();

        while (manoCrupier.CalcularTotal() < 17)
        {
            Console.WriteLine("\n🎴 El crupier pide carta...\n");
            System.Threading.Thread.Sleep(1500);
            
            manoCrupier.AgregarCarta(baraja.RepartirCarta());
            manoCrupier.MostrarMano();
        }

        
        int totalJugador = manoJugador.CalcularTotal();
        int totalCrupier = manoCrupier.CalcularTotal();

        Console.WriteLine("\n" + new string('═', 55));
        Console.WriteLine("              RESULTADO FINAL ");
        Console.WriteLine(new string('═', 55));
        Console.WriteLine($"  Jugador: {totalJugador} puntos");
        Console.WriteLine($"  Crupier: {totalCrupier} puntos");
        Console.WriteLine(new string('═', 55) + "\n");

        if (totalCrupier > 21)
        {
            Console.WriteLine(" ¡GANASTE! El crupier se pasó de 21.");
        }
        else if (totalJugador > totalCrupier)
        {
            Console.WriteLine(" ¡GANASTE! Tu mano es mejor.");
        }
        else if (totalJugador < totalCrupier)
        {
            Console.WriteLine(" Perdiste. El crupier tiene mejor mano.");
        }
        else
        {
            Console.WriteLine(" ¡EMPATE! Misma puntuación.");
        }

        Console.WriteLine("\n Presiona cualquier tecla para volver al menú...");
        Console.ReadKey();
    }
}