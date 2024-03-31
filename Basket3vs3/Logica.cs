
public class Partido
{
    private Equipo equipoLocal;
    private Equipo equipoVisitante;
    private List<IJugador> jugadoresDisponibles;

    public Partido()
    {
        equipoLocal = new Equipo("Equipo Local");
        equipoVisitante = new Equipo("Equipo Visitante");
        jugadoresDisponibles = new List<IJugador>
        {
            new Jugador("Lebron James"),
            new Jugador("Stephen Curry"),
            new Jugador("Kevin Durant"),
            new Jugador("Michael Jordan 23"),
            new Jugador("Jason Tatum"),
            new Jugador("James Harden"),
            new Jugador("Luka Doncic"),
            new Jugador("Anthony Davis"),
            new Jugador("Joel Embiid"),
            new Jugador("Nikola Jokic")
        };
    }

    public void RepartirJugadores()
    {
        Random rr = new Random();
        for (int i = 0; i < 6; i++)
        {
            int indice = rr.Next(jugadoresDisponibles.Count);
            IJugador JugarRepartido = jugadoresDisponibles[indice];
            jugadoresDisponibles.RemoveAt(indice);

            if (i % 2 == 0)
            {
                equipoLocal.AggJugador(JugarRepartido);
            }
            else
            {
                equipoVisitante.AggJugador(JugarRepartido);
            }
        }
        Console.WriteLine("Jugadores repartidos correctamente.");
    }

    public void MostrarJugadoresEnEquipos()
    {
        Console.WriteLine("");
        Console.WriteLine("=====================Local==================");
        Console.WriteLine("");
        equipoLocal.ListaDeJugadores();
        Console.WriteLine("");
        Console.WriteLine("===================Visitante================");
        Console.WriteLine("");
        equipoVisitante.ListaDeJugadores();
        Console.WriteLine("");
    }

    public void ComenzarPartido()
    {
        Console.WriteLine("===================Resultados====================");
        Console.WriteLine("");
        int Sumadelocal = equipoLocal.SumaDeRendimiento();
        int SumaVisitante = equipoVisitante.SumaDeRendimiento();

        Console.WriteLine($"Rendimiento total del equipo local: {equipoLocal.SumaDeRendimiento()}");
        Console.WriteLine($"Rendimiento total del equipo visitante: {equipoVisitante.SumaDeRendimiento()}");

        if (Sumadelocal > SumaVisitante)
        {
            Console.WriteLine("El equipo local gana con un rendimiento total de: " + Sumadelocal);
            Console.WriteLine("________________________________________");
        }
        else if (SumaVisitante > Sumadelocal)
        {
            Console.WriteLine("El equipo visitante gana con un rendimiento total de: " + SumaVisitante);
            
        }
        else
        {
            Console.WriteLine("El partido termina en empate.");
        }
    }

       public void VerJugadoresDisponibles()
    {
        Console.WriteLine("_________________________");
        Console.WriteLine("Jugadores disponibles:");
        Console.WriteLine("_________________________");
        foreach (var jugador in jugadoresDisponibles)
        {
            Console.WriteLine(jugador.Nombre);
        }
    }

    public void IngresarNuevoJugador(string nombre)
    {
        jugadoresDisponibles.Add(new Jugador(nombre));
        Console.WriteLine($"Jugador {nombre} agregado correctamente.");
    }
}