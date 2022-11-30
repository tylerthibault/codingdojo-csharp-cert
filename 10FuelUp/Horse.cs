public class Horse : Vehicle, INeedFuel
{
    public string FuelType {get;set;} = "Hay";
    public int FuelTotal {get;set;} = 0;

    public Horse(string name, int numPassengers, string color, bool hasEngine, int topSpeed, string FuelType) : base(name, numPassengers, color, hasEngine, topSpeed)
    {
        System.Console.WriteLine($"A new Horse has been created!");
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal += Amount;
    }
}