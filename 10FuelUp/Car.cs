public class Car : Vehicle, INeedFuel
{
    public string FuelType {get;set;}
    public int FuelTotal {get;set;} = 0;

    public Car(string name, int numPassengers, string color, bool hasEngine, int topSpeed, string fuelType) : base(name, numPassengers, color, hasEngine, topSpeed)
    {
        System.Console.WriteLine($"A new Car has been created!");
        FuelType = fuelType;
    }

    public void GiveFuel(int Amount) 
    {
        FuelTotal += Amount;
    }
}