
Soda Coke = new Soda("Coke", "black", 45, true, 150, true);

// Coke.ShowInfo();

Coffee Sumateran = new Coffee("Sumateran", "Black", 80, false, 0, "dark", "Sumateran");

// Sumateran.ShowInfo();

Wine Red = new Wine("Red", "red", 60, false, 100, "Perump", "2008");

// Red.showInfo();

List<Drink> AllDrinks = new List<Drink>() {
    Coke, 
    Sumateran,
    Red
};

foreach (var item in AllDrinks)
{
    System.Console.WriteLine("******** NEW DRINK **********");
    item.ShowInfo();
}