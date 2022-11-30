public class Coffee : Drink
{
    private string Roast;
    private string Bean;

    public Coffee(string name, string color, double temp, bool isCarbonated, int calories, string roast, string bean) : base(name, color, temp, isCarbonated, calories)
    {
        Roast = roast;
        Bean = bean;
    }

    public void ShowInfo()
    {
        base.ShowInfo();
        System.Console.WriteLine($"Roast: {Roast}");
        System.Console.WriteLine($"Bean: {Bean}");
    }
}