namespace PokemonG;
class Program
{
    //Inicialización de los pokemones para poder utilizarlos en cada uno de los metodos estaticos (Uso del constructor vacio)
    static Pokemon Pokemon1 = new Pokemon();
    static Pokemon Pokemon2 = new Pokemon();
    static void Main(string[] args)
    {
        bool Exit = false;
        int option;
        bool SetP = false;

        do
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("|  Welcome to PokemonG    |");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| 1.Set Pokemons          |");
            Console.WriteLine("| 2.Combat                |");
            Console.WriteLine("| 3.Show Info             |");
            Console.WriteLine("| 4.Exit                  |");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("OPTION: ");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    SetPokemons();
                    SetP = true;
                    break;
                case 2:
                    if (SetP)
                        CombatPokemons();
                    else
                        Console.WriteLine("Please set Pokemons!");
                    break;
                case 3:
                    ShowInfo();
                    break;
                case 4:
                    Exit = true;
                    break;
                default:
                    Console.WriteLine("INCORRECT OPTION! Please select again");
                    break;
            }
        } while (!Exit);
    }

    static void SetPokemons()
    {
        String Name = "";
        String Type = "";
        decimal Health = 0;

        Random rnd = new Random();

        Console.WriteLine("----- POKEMON 1 -----");
        Console.WriteLine("Enter Pokemon's name: ");
        Name = Console.ReadLine();
        Console.WriteLine("Enter Pokemon's Type: ");
        Type = Console.ReadLine();
        Console.WriteLine("Enter Pokemon's Health: ");
        Health = int.Parse(Console.ReadLine());

        //Utilización del segundo contructor para hacer set de atributos
        Pokemon1 = new Pokemon(Name, Type, Health, new int[] { rnd.Next(0, 40), rnd.Next(0, 40), rnd.Next(0, 40) }, new int[] { rnd.Next(10, 35), rnd.Next(10, 35) });

        Console.WriteLine("----- POKEMON 2 -----");
        Console.WriteLine("Enter Pokemon's name: ");
        Name = Console.ReadLine();
        Console.WriteLine("Enter Pokemon's Type: ");
        Type = Console.ReadLine();
        Console.WriteLine("Enter Pokemon's Health: ");
        Health = int.Parse(Console.ReadLine());

        //Utilización del segundo contructor para hacer set de atributos
        Pokemon2 = new Pokemon(Name, Type, Health, new int[] { rnd.Next(0, 40), rnd.Next(0, 40), rnd.Next(0, 40) }, new int[] { rnd.Next(10, 35), rnd.Next(10, 35) });


    }

    static void CombatPokemons()
    {
        for (int i = 0; i < 3; i++)
        {
            //Se obtiene las defensas y atques al azar de ambos pokemones
            decimal APokemon1 = Pokemon1.Attack();
            decimal DPokemon1 = Pokemon1.Defend();

            decimal APokemon2 = Pokemon2.Attack();
            decimal DPokemon2 = Pokemon2.Defend();

            //COMBATE: ATAQUE DEL POKEMON 1 AL POKEMON 2
            //Si la defensa del pokemon que es atacado es mayor al atacante se le resta la diferencia a la salud del atacante
            if (DPokemon2 > APokemon1)
                Pokemon1.Damage(DPokemon2 - APokemon1);
            //Si el ataque es mayor que la defensa del pokemon que es atacado se le resta la diferencia a la salud del atacado
            if (DPokemon2 < APokemon1)
                Pokemon2.Damage(APokemon1 - DPokemon2);

            //COMBATE: ATAQUE DEL POKEMON 2 AL POKEMON 1
            //Si la defensa del pokemon que es atacado es mayor al atacante se le resta la diferencia a la salud del atacante
            if (DPokemon1 > APokemon2)
                Pokemon2.Damage(APokemon1 - APokemon2);
            //Si el ataque es mayor que la defensa del pokemon que es atacado se le resta la diferencia a la salud del atacado
            if (DPokemon1 < APokemon2)
                Pokemon1.Damage(APokemon2 - DPokemon1);

            if (Pokemon1.getHealth() < 0 || Pokemon2.getHealth() < 0) //En caso de que la salud de uno de los pokemones sea negativa no se muestra los resultados del turno y se procede a frenar el ciclo
            {
                break;
            }
            else //En caso de que alguno de los pokemones aún tenga salud
            {
                Console.WriteLine($"-------- TURN {i + 1} --------");
                Console.WriteLine("POKEMON 1   |  POKEMON 2");
                Console.WriteLine($"Attack: {APokemon1}  | {APokemon2}");
                Console.WriteLine($"Defense: {DPokemon1} | {DPokemon2}");
                Console.WriteLine($"Health: {Pokemon1.getHealth()} | {Pokemon2.getHealth()}");
            }
        }

        Console.WriteLine("-------- FINAL --------");
        if (Pokemon1.getHealth() < Pokemon2.getHealth())
            Console.WriteLine($"Pokemon {Pokemon2.getName()} win!");
        else if (Pokemon2.getHealth() < Pokemon1.getHealth())
            Console.WriteLine($"Pokemon {Pokemon1.getName()} win!");
    }

    static void ShowInfo()
    {
        Console.WriteLine("---- POKEMON 1 ----");
        Pokemon1.ShowInfo();
        Console.WriteLine("---- POKEMON 2 ----");
        Pokemon2.ShowInfo();
    }
}
