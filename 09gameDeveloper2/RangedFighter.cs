public class RangedFighter : Enemy
{
    private int Distance = 5;
    public int _Distance {get;}

    public RangedFighter(string name, int distance = 5) : base(name) {
        Distance = distance;
        System.Console.WriteLine($"A Ranged Fighter was created by the name of {_Name}");
    }

    public void RandomAttack()
    {
        if (Distance > 10)
        {
            Attack attack = base.RandomAttack();
        }
        else 
        {
            System.Console.WriteLine("You are too close to attack.");
        }
    }

    public void Dash()
    {
        Distance = 20;
    }
}