// See https://aka.ms/new-console-template for more information

// ARRS
int[] arr1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
string[] arr2 = { "Tim", "Martin", "Nikki", "Sara" };
bool[] arr3 = new bool[10];

for (int i = 0; i < arr3.Length; i++)
{
    if (i % 2 == 0)
    {
        arr3[i] = true;
    }
    else
    {
        arr3[i] = false;
    }
}

// LISTS

List<String> iceCream = new List<string>();
iceCream.Add("vanilla");
iceCream.Add("chocolate");
iceCream.Add("chocolate chip mint");
iceCream.Add("strawberry");
iceCream.Add("blueberry");


foreach (var item in iceCream)
{
    System.Console.WriteLine(item);
}

System.Console.WriteLine("****************");

System.Console.WriteLine(iceCream[2]);
iceCream.RemoveAt(3);

System.Console.WriteLine("****************");

foreach (var item in iceCream)
{
    System.Console.WriteLine(item);
}

System.Console.WriteLine("****************");

System.Console.WriteLine(iceCream.Count());

// DICTS
System.Console.WriteLine("************DICTIONARIES***********");
Dictionary<string, string> people = new Dictionary<string, string>();

Random rand = new Random();

foreach (var item in arr2)
{
    int personIdx = rand.Next(0, arr2.Length);
    string person = arr2[personIdx];
    int iceCreamIdx = rand.Next(0, iceCream.Count());
    string iceCreamActual = iceCream[iceCreamIdx];

    bool keyExits = people.ContainsKey(person);
    if (!keyExits)
    {
        people.Add(person, iceCreamActual);
    }
}

foreach (var item2 in people)
{
    System.Console.WriteLine(item2);
}
