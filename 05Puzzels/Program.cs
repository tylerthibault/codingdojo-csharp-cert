// See https://aka.ms/new-console-template for more information

// Print List
static void PrintListInt(List<int> IncomingList)
{
    foreach (var item in IncomingList)
    {
        System.Console.WriteLine(item);
    }
}

// COIN FLIP
static string CoinFlip()
{
    Random rand = new Random();
    int num = rand.Next(0, 100);
    if (num % 2 == 0) return "Heads";
    return "Tails";
}
System.Console.WriteLine(CoinFlip());
System.Console.WriteLine("****************");

// DICE ROLL
static int DiceRoll(int sides = 6)
{
    Random rand = new Random();
    int num = rand.Next(1, sides);
    return num;
}
System.Console.WriteLine(DiceRoll(20));
System.Console.WriteLine("****************");

// STAT ROLL
static List<int> StatRoll()
{
    List<int> Stats = new List<int>();
    for (int i = 0; i < 4; i++)
    {
        Stats.Add(DiceRoll());
    }
    return Stats;
}
PrintListInt(StatRoll());
System.Console.WriteLine("****************");

// ROLL UNTIL
static void RollUntil(int NumLookingFor)
{
    bool isValid = true;
    if (NumLookingFor > 6 || NumLookingFor <= 0)
    {
        System.Console.WriteLine("Number is out of range");
        isValid = false;
    }
    if (isValid)
    {
        Random rand = new Random();
        int Num = 0;
        int Count = 0;
        while (NumLookingFor != Num)
        {
            Num = rand.Next(1, 6);
            Count++;
        }
        System.Console.WriteLine($"You rolled a {NumLookingFor} and it took you {Count} times");
    }
}
System.Console.WriteLine("What number do you want to try to roll?");
string Numb = Console.ReadLine();
int NumbConverted = Convert.ToInt32(Numb);
RollUntil(NumbConverted);