public class Bicycle : Vehicle
{
    public Bicycle(string name, int numPassengers, string color, bool hasEngine, int topSpeed) : base(name, numPassengers, color, hasEngine, topSpeed)
    {
        System.Console.WriteLine($"A new Bicycle has been created!");
    }
}