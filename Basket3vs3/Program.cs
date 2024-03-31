public class Program
{
    static void Main(string[] args)
    {
        Partido inicializadorBasquet = new Partido();
        int opcion;
        do
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("1 -> Repartir jugadores");
            Console.WriteLine("2 -> Mostrar jugadores en equipos");
            Console.WriteLine("3 -> Jugar");
            Console.WriteLine("4 -> Ver jugadores disponibles");
            Console.WriteLine("5 -> Agregar un nuevo jugador");
            Console.WriteLine("6 -> Salir");
            Console.Write("Ingrese su opcion deseada: ");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    inicializadorBasquet.RepartirJugadores();
                    break;
                case 2:
                    inicializadorBasquet.MostrarJugadoresEnEquipos();
                    break;
                case 3:
                    inicializadorBasquet.ComenzarPartido();
                    break;
                case 4:
                    inicializadorBasquet.VerJugadoresDisponibles();
                    break;
                    
                case 5:
                    Console.Write("Ingrese el nombre del nuevo jugador: ");
                    var nombreNuevoJugador = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nombreNuevoJugador))
                    {
                        inicializadorBasquet.IngresarNuevoJugador(nombreNuevoJugador);
                    }
                    else
                    {
                        Console.WriteLine("Nombre de jugador no válido. Inténtelo de nuevo.");
                    }
                    break;


                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                    
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        } while (opcion != 6);
    }
}
