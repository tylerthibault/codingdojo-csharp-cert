
int[] arr1 = {0,1,2,3,4,5,6,7,8,9};

string[] arr2 = {"Tim", "Martin", "Nikki", "Sara"};

bool[] arr3 = {
    true,
    false,
    true,
    false,
    true,
    false,
    true,
    false,
    true,
    false,
    true,
    false,
};

bool[] arr = new bool[10];

for (int i = 0; i < arr.Length; i++) {
    arr[i] = (i % 2 == 0) ? true : false;
}



List<string> icecream = new List<string>();
icecream.Add("vanilla");
icecream.Add("chocolate");
icecream.Add("strawberry");
icecream.Add("blueberry");
icecream.Add("marshmellow");

// System.Console.WriteLine(icecream.Count);
string flavor = icecream[2];
// System.Console.WriteLine(flavor);
// icecream.RemoveAt(2);
icecream.Remove(flavor);
// System.Console.WriteLine(icecream.Count);

Random rand = new Random();

// System.Console.WriteLine(rand.Next(20));

Dictionary<string,string> people = new Dictionary<string,string>();

foreach (var person in arr2)
{
    people.Add(person, icecream[rand.Next(icecream.Count)]);
}

foreach (var item in people)
{
    System.Console.WriteLine(item);
}
