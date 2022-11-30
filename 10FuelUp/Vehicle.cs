public abstract class Vehicle
{
    private string Name;
    private int NumPassengers;
    private string Color;
    private bool HasEngine;
    private int TopSpeed;
    private int Miles;

    public Vehicle(string name, int numPassengers, string color, bool hasEngine, int topSpeed)
    {
        Name = name;
        NumPassengers = numPassengers;
        Color = color;
        HasEngine = hasEngine;
        TopSpeed = topSpeed;
        Miles = 0;
    }
    public Vehicle(string name, string color)
    {
        Name = name;
        Color = color;
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