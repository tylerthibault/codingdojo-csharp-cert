// See https://aka.ms/new-console-template for more information

// Problem 1
static void PrintList(List<int> MyList)
{
    foreach (var item in MyList)
    {
        System.Console.WriteLine(item);
    }
}

List<string> list1 = new List<string>() { "tyler", "joe", "curtis" };
// PrintList(list1);


// Problem 2
static int SumOfNumbers(List<int> IntList)
{
    // Your code here
    int sum = 0;
    foreach (var item in IntList)
    {
        sum += item;
    }
    return sum;
}

List<int> someNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
// System.Console.WriteLine(SumOfNumbers(someNumbers));

// Problem 3

static int FindMax(List<int> IntList)
{
    // Your code here
    int max = IntList[0];
    foreach (var item in IntList)
    {
        if (item > max)
        {
            max = item;
        }
    }
    return max;
}

// System.Console.WriteLine(FindMax(someNumbers));

// 4. Square the Values
static List<int> SquareValues(List<int> IntList)
{
    // Your code here
    for (int i = 0; i < IntList.Count(); i++)
    {
        IntList[i] = IntList[i] * IntList[i];
    }
    return IntList;
}
// PrintList(SquareValues(someNumbers));

// 5. Replace Negative Numbers with 0
static int[] NonNegatives(int[] IntArray)
{
    // Your code here
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
    }
    return IntArray;
}

int[] mixedNumbers  = new int[] {1,-2,-3,4,5};
// int[] something = NonNegatives(mixedNumbers);
// foreach (var item in something)
// {
//     System.Console.WriteLine(item);
// }

// 6. Print Dictionary
static void PrintDictionary(Dictionary<string,int> MyDictionary)
{
    // Your code here
    foreach (var item in MyDictionary)
    {
        System.Console.WriteLine($"{item.Key}: {item.Value}");
    }
}

Dictionary<string,string> People = new Dictionary<string, string>();
People.Add("firstName", "Tyler");
People.Add("lastName", "Thibault");
People.Add("age", "32");

// PrintDictionary(People);


// 7. Find Key
static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    // Your code here
    // if (MyDictionary.ContainsKey(SearchTerm)) return true;
    // return false;

    foreach (var item in MyDictionary)
    {
        if(item.Key == SearchTerm) return true;
    }
    return false;
}

// System.Console.WriteLine(FindKey(People, "firstName"));

// 8. Generate a Dictionary
// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    // Your code here
    Dictionary<string, int> ReturnDict = new Dictionary<string, int>();
    for (int i = 0; i < Names.Count(); i++)
    {
        ReturnDict.Add(Names[i], Numbers[i]);
    }
    return ReturnDict;
}

List<string> Names = new List<string>() {"Julie", "Harold", "James", "Monica"};
List<int> Ages = new List<int>(){6,12,7,10};

Dictionary<string, int> Outcome = GenerateDictionary(Names, Ages);
PrintDictionary(Outcome);