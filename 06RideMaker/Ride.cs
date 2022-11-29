public class Ride
{
    private string Name;
    private int NumPassengers;
    private string Color;
    private bool HasEngine;
    private int TopSpeed;
    private int Miles;

    public Ride(string n, int np, string c, bool he, int ts)
    {
        Name = n;
        NumPassengers = np;
        Color = c;
        HasEngine = he;
        TopSpeed = ts;
        Miles = 0;
    }
    public Ride(string n, string c)
    {
        Name = n;
        Color = c;
        NumPassengers = 2;
        HasEngine = true;
        TopSpeed = 90;
        Miles = 0;
    }
    public void ShowInfo()
    {
        System.Console.WriteLine($"************ {Name} ************");
        System.Console.WriteLine($"NumPassengers: {NumPassengers}");
        System.Console.WriteLine($"Color: {Color}");
        System.Console.WriteLine($"HasEngine: {HasEngine}");
        System.Console.WriteLine($"TopSpeed: {TopSpeed}");
        System.Console.WriteLine($"Miles: {Miles}");
    }

    public void Travel(int Distance)
    {
        Miles = Distance;
        System.Console.WriteLine($"\n>>> {Name} has traveled {Miles} so far.\n");
    }
}