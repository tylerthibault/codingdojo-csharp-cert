public class Enemy
{
    private string Name;
    public string _Name {get;}
    private int Health;
    private List<Attack> Attacks;
    public List<Attack> _Attacks {get;set;}

    public Enemy(string name)
    {
        Name = name;
        Health = 100;
        Attacks = new List<Attack>();
    }

    public void AddAtack(Attack NewAttack)
    {
        Attacks.Add(NewAttack);
    }

    public void showAttacks()
    {
        foreach (var item in Attacks)
        {
            System.Console.WriteLine("Showing Attacks");
            System.Console.WriteLine(item.Name);
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