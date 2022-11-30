public class MeleeFighter : Enemy
{
    
    public MeleeFighter(string name) : base(name)
    {
        _Health = 120;
        System.Console.WriteLine($"A Melee Fighter was created by the name of {_Name}");
    }

    public void Rage()
    {
        Attack attack = base.RandomAttack();
        int Damage = attack._Damage + 10;
        System.Console.WriteLine($"You did an extra 10 damage for a total of {Damage} damage.");
    }
}