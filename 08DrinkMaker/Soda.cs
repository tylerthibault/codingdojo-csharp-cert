public class Soda : Drink
{
    private bool Diet;

    public Soda(string name, string color, double temp, bool isCarbonated, int calories, bool diet) : base(name, color, temp, isCarbonated, calories)
    {
        Diet = diet;
    }

    public void ShowInfo()
    {
        base.ShowInfo();
        System.Console.WriteLine($"Diet: {Diet}");
    }
}