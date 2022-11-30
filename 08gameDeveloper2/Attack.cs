public class Attack
{
    public string Name;
    private int Damage;
    public int _Damage {get;set;}

    public Attack(string name, int damage)
    {
        Name = name;
        _Damage = damage;
    }
}