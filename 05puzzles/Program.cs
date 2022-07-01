

static int[] RandomArr()
{
    int[] returnArr = new int[10];
    Random rand = new Random();
    int min = 26;
    int max = 0;
    int sum = 0;
    for (var i=0; i<returnArr.Length; i++)
    {   
        int randomNumber = rand.Next(5,25);
        
        if (randomNumber > max)
        {
            max = randomNumber;
        }
        if (randomNumber < min)
        {
            min = randomNumber;
        }
        sum = sum + randomNumber;
        returnArr[i] = randomNumber;
    }
    System.Console.WriteLine($"min: {min} || max: {max} || sum: {sum}");
    return returnArr;
}

// foreach (var item in RandomArr())
// {
//     System.Console.WriteLine(item);
// }

static string CoinFlip()
{
    System.Console.WriteLine("Tossing a Coin!");
    Random rand = new Random();
    int num = rand.Next(3);
    System.Console.WriteLine(num);
    string outcome = num <= 1 ? "heads" : "tails";
    return outcome;
}

// System.Console.WriteLine(CoinFlip());

static double TossMultipleCoins(int num)
{
    int count = 0;
    for (var i=0; i<num; i++)
    {
        if (CoinFlip() == "heads") 
        {
            count++;
        }
    }
    double ratio = (double)count / (double)num;
    // System.Console.WriteLine($"count: {count} || num: {num} || ratio: {ratio} ");
    return ratio;
}

// System.Console.WriteLine(TossMultipleCoins(5));

static List<string> Names()
{
    List<string> nameOptions = new List<string> {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
    for (var i=0; i<nameOptions.Count; i++)
    {
        string name = nameOptions[i];
        if (name.Length <= 5)
        {
            nameOptions.Remove(name);
        }
    }
    return nameOptions;
}

foreach (var item in Names())  
{
    System.Console.WriteLine(item);
}