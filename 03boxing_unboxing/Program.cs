
List<object> newObjList = new List<object>();

newObjList.Add(7);
newObjList.Add(28);
newObjList.Add(-1);
newObjList.Add(true);
newObjList.Add("chair");

int sum = 0;
foreach (var item in newObjList)
{
    if (item is int)
    {
        sum = sum + (int)item;
    }
}
System.Console.WriteLine(sum);