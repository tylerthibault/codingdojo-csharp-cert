public class Enemy
{
    private string Name;
    public string _Name {get;set;}
    private int Health;
    public int _Health {get;set;}
    private List<Attack> Attacks;
    public List<Attack> _Attacks {get;set;}

    public Enemy(string name)
    {
        _Name = name;
        Health = 100;
        Attacks = new List<Attack>();
    }
    public Enemy(string name, int health)
    {
        _Name = name;
        Health = health;
        Attacks = new List<Attack>();
    }

    public void AddAtack(Attack NewAttack)
    {
        Attacks.Add(NewAttack);
    }

    public void ShowAttacks()
    {
        foreach (var item in Attacks)
        {
            System.Console.WriteLine("Showing Attacks");
            System.Console.WriteLine(item.Name);
            System.Console.WriteLine(item._Damage);
        }
    }

    public Attack RandomAttack()
    {
        Random rand = new Random();
        int RandIdx = rand.Next(0, Attacks.Count());
        Attack AttackActual = Attacks[RandIdx];
        System.Console.WriteLine($"{Name} is {AttackActual.Name} ");
        return AttackActual;
    }
}