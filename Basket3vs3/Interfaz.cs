//Es trabajo honesto

//interfaz IJugador co propiedades Nombre y Rendimieto
public interface IJugador
{
    string Nombre { get; }
    int Rendimiento { get; }
}

//encapsula el nombre y rendimiento de propiedad privadass
public class Jugador : IJugador
{
    private string nombre;
    private int rendimiento;

// Constructor para inicializar el nombre y rendimiento
    public Jugador(string nombre)
    {
        this.nombre = nombre;
        this.rendimiento = new Random().Next(1, 11);
    }

//  acceder al nombre del jugador
    public string Nombre
    {
        get
        {
            return nombre;
        }
    }

// acceder al rendimiento del jugador
    public int Rendimiento
    {
        get
        {
            return rendimiento;
        }
    }
}
// Clase Equipo encapsula la información de un equipo
public class Equipo
{
    private string nombre;
    private List<IJugador> jugadores;

// Constructor para inicializar el nombre del equipo
    public Equipo(string nombre)
    {
        this.nombre = nombre;
        this.jugadores = new List<IJugador>();
    }

    public void AggJugador(IJugador jugador)
    {
        jugadores.Add(jugador);
    }

    public int SumaDeRendimiento()
    {
        int total = 0;
        foreach (var jugador in jugadores)
        {
            total = total + jugador.Rendimiento;
        }
        return total;
    }

    public void ListaDeJugadores()
    {
        Console.WriteLine($"Jugadores en el {nombre}:");
        Console.WriteLine("________________________________________");
        foreach (var jugador in jugadores)
        {
            Console.WriteLine($"{jugador.Nombre} -----> Rendimiento: {jugador.Rendimiento}");
            
        }
    }


}
