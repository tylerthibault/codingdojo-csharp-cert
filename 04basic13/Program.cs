static void PrintNumbers()
{
    for (var i=1; i<=255; i++)
    {
        System.Console.WriteLine(i);
    }
}
// PrintNumbers();

static void PrintOdds()
{
    for (var i=1; i<=255; i++)
    {
        if (i % 2 == 1)
        {
            System.Console.WriteLine(i);
        }
    }
}
// PrintOdds();

static void PrintSum()
{
    int sum = 0;
    for (var i=1; i<=255; i++)
    {
        sum = sum + i;
        System.Console.WriteLine($"New Number: {i} Sum: {sum}");
    }
}
// PrintSum();

static void LoopArray(int[] nums)
{
    foreach (var item in nums)
    {
        System.Console.WriteLine(item);
    }
}
// LoopArray(new int[] {1,2,3,4,5,6,7,8,9});

static void FindMax(int[] nums)
{
    int max = nums[0];
    foreach (var num in nums)
    {
        if (num > max)
        {
            max = num;
        }
    }
    System.Console.WriteLine(max);
}
// FindMax(new int[] {0, -3,-5, 9, -7});

static void GetAerage(int[] nums)
{
    // int total = 0;
    // foreach (var num in nums)
    // {
    //     total = total + num;
    // }
    // int average = total / nums.Count;
    // System.Console.WriteLine(average);
    System.Console.WriteLine(nums.Average());
}
// GetAerage(new int[] {2,10,3});

static int[] oddArray()
{
    int[] arr = new int[128];
    int count = 0;
    for (var i=0; i<255; i++)
    {
        int num = i + 1;
        if (num % 2 == 1)
        {
            arr[count] = num;
            count++;
        }
    }
    return arr;
}
// foreach (var item in oddArray())
// {
//     System.Console.WriteLine(item);
// }

static int GreaterThanY(int[] nums, int y)
{
    int count = 0;
    foreach (var num in nums)
    {
        if (num > y)
        {
            count++;
        }
    }
    return count;
}
// System.Console.WriteLine(GreaterThanY(new int[] {1,3,2,5,7,1,2,4,8,2,5,3,5,6}, 3));

static void SquareArrayValues(int[] nums)
{
    for (var i=0; i<nums.Length; i++)
    {
        int currentNum = nums[i];
        nums[i] = currentNum * currentNum;
    }
    
    foreach (var item in nums)
    {
        System.Console.WriteLine(item);
    }
}
// SquareArrayValues(new int[] {1,5,10,-10});


static void EliminateNegatives(int[] nums)
{
    for (var i=0; i<nums.Length; i++)
    {
        if (nums[i] < 0)
        {
            nums[i] = 0;
        }
    }

    foreach (var item in nums)
    {
        System.Console.WriteLine(item);
    }
}

// EliminateNegatives(new int[] {1, 5, 10, -2});

static void ShiftValues(int[] nums)
{
    for (var i=0; i<nums.Length; i++)
    {
        if (i != nums.Length - 1)
        {
            nums[i] = nums[i + 1];
        }
        else 
        {
            nums[i] = 0;
        }
    }

    foreach (var num in nums)
    {
        System.Console.WriteLine(num);
    }
}
// ShiftValues(new int[] {1,5,10,7,-1});


static object[] NumToString(int[] nums)
{
    object[] returnArr = new object[nums.Length];
    for (var i=0; i<nums.Length; i++)
    {
        if (nums[i] < 0)
        {
            returnArr[i] = "Dojo";
        }
        else 
        {
            returnArr[i] = nums[i];
        }
    }
    return returnArr;
}

foreach (var item in NumToString(new int[] {1,2,-2, -8}))
{
    System.Console.WriteLine(item);
}