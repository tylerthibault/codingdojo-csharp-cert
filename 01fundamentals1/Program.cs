// See https://aka.ms/new-console-template for more information


// Problem 1
// for (int i = 0; i < 255; i++)
// {
//     System.Console.WriteLine(i);
// }

// Problem 2
Random rand = new Random();
int sum = 0;
for (int i = 0; i < 5; i++)
{
    int number = rand.Next(10, 20);
    // System.Console.WriteLine("random number: " + number);
    sum += number;
}
// System.Console.WriteLine(sum);


// Problem 3
for (int i = 0; i < 100; i++)
{
    if (i % 5 == 0)
    {
        if (i % 3 != 0)
        {
            // System.Console.WriteLine(i);
        }
    }
    else if (i % 3 == 0)
    {
        if (i % 5 != 0)
        {
            // System.Console.WriteLine(i);
        }
    }
}


// Problem 4
for (int i = 0; i < 100; i++)
{
    if (i % 5 == 0)
    {
        if (i % 3 != 0)
        {
            // System.Console.WriteLine("Buzz");
        }
    }
    else if (i % 3 == 0)
    {
        if (i % 5 != 0)
        {
            // System.Console.WriteLine("Fizz");
        }
    }
}

// Problem 5
for (int i = 0; i < 100; i++)
{
    if (i % 5 == 0)
    {
        if (i % 3 == 0)
        {
            // System.Console.WriteLine("FizzBuzz");
        }
        else
        {
            // System.Console.WriteLine("Buzz");
        }
    }
    else if (i % 3 == 0)
    {
        if (i % 5 == 0)
        {
            // System.Console.WriteLine("BuzzFizz");
        }
        else
        {
            // System.Console.WriteLine("Fizz");
        }
    }
}

// Problem 6
int indx = 0;
while (indx < 100)
{
    if (indx % 5 == 0)
    {
        if (indx % 3 == 0)
        {
            System.Console.WriteLine("FizzBuzz");
        }
        else
        {
            System.Console.WriteLine("Buzz");
        }
    }
    else if (indx % 3 == 0)
    {
        if (indx % 5 == 0)
        {
            System.Console.WriteLine("BuzzFizz");
        }
        else
        {
            System.Console.WriteLine("Fizz");
        }
    }
    indx++;
}