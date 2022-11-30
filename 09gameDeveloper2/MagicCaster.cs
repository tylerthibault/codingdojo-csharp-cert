public class MagicCaster : Enemy 
{
    public MagicCaster(string name) : base(name, 80)
    {
        System.Console.WriteLine($"A Magic Caster was created by the name of {_Name}");
    }

    public void Heal(Enemy Target)
    {
        Target._Health += 40;
        System.Console.WriteLine($"{Target._Name} was healed for 40 points and is now at a health level of {Target._Health}");

    }
}