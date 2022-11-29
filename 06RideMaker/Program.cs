Ride R1 = new Ride("car1",3, "black", true, 100);
Ride R2 = new Ride("car2",2, "red", true, 150);
Ride R3 = new Ride("car3",4, "white", true, 100);
Ride R4 = new Ride("car4",4, "blue", true, 100);

List<Ride> AllRides = new List<Ride>();
AllRides.Add(R1);
AllRides.Add(R2);
AllRides.Add(R3);
AllRides.Add(R4);

foreach (var item in AllRides)
{
    item.ShowInfo();
}

R3.Travel(100);
R3.ShowInfo();