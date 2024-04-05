namespace PokemonG;
//Interface para las acciones de los pokemones
public interface IPokemon
{
    decimal Attack();
    decimal Defend();
}

//Clase que contiene las propiedades y hereda las acciones de la interfaz IPokemon
public class Pokemon : IPokemon
{
    private string Name { get; set; }
    private string Type { get; set; }
    private decimal Health { get; set; }
    private int[] Attacks { get; set; }
    private int[] Defenses { get; set; }

    //Constructor vacio para iniciaizar los dos pokemones en el principal Program
    public Pokemon()
    {

    }
    //Constructor que se utiliza después de pedir los datos al usuario
    public Pokemon(string Name, string Type, decimal Health, int[] Attacks, int[] Defenses)
    {
        this.Name = Name;
        this.Type = Type;
        this.Health = Health;
        this.Attacks = Attacks;
        this.Defenses = Defenses;
    }

    public decimal Attack()
    {
        Random rnd = new Random();
        int RandomAttack = rnd.Next(Attacks.Length);
        decimal [] Power = new decimal[]{1, 0, 1.5m};
        int RandomPower = rnd.Next(Power.Length);
        return this.Attacks[RandomAttack] * Power[RandomPower];

    }

    public decimal Defend()
    {
        Random rnd = new Random();
        int RandomDefense = rnd.Next(Defenses.Length);
        decimal [] Power = new decimal[]{1, 0.5m};
        int RandomPower = rnd.Next(Power.Length);
        return this.Defenses[RandomDefense] * Power[RandomPower];
    }

    public void Damage(decimal Damage)
    {
        this.Health -= Damage;
    }

    public decimal getHealth()
    {
        return this.Health;
    }

    public string getName()
    {
        return this.Name;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"NAME: {this.Name}");
        Console.WriteLine($"TYPE: {this.Type}");
        Console.WriteLine($"HEALTH: {this.Health}");
        Console.WriteLine("ATTACKS:");
        foreach (int attack in this.Attacks){
            Console.WriteLine($"{attack}");
        }
        Console.WriteLine("DEFENSES:");
        foreach (int defense in this.Defenses){
            Console.WriteLine($"{defense}");
        }
        
    }
}
