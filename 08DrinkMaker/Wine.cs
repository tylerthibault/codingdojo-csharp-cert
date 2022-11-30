public class Wine : Drink
{
    private string Region;
    private string Year;

    public Wine(string name, string color, double temp, bool isCarbonated, int calories, string region, string year) : base (name, color, temp, isCarbonated, calories)
    {
        Region = region;
        Year = year;
    }

    public void showInfo()
    {
        base.ShowInfo();
        System.Console.WriteLine($"Region: {Region}");
        System.Console.WriteLine($"Year: {Year}");
    }
}