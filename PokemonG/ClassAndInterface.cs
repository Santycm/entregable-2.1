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
        return Attacks[RandomAttack] * 1 * 1.5m;

    }

    public decimal Defend()
    {
        Random rnd = new Random();
        int RandomDefense = rnd.Next(Defenses.Length);
        return Defenses[RandomDefense] * 1 * 0.5m;
    }

    public void Damage(decimal Damage)
    {
        Health -= Damage;
    }

    public decimal getHealth()
    {
        return Health;
    }

    public string getName()
    {
        return Name;
    }
}