

Attack A1 = new Attack("Punching", 15);
Attack A2 = new Attack("Kicking", 20);
Attack A3 = new Attack("Head Butting", 10);


Enemy E1 = new Enemy("Tyler");
Enemy E2 = new Enemy("Joe");
Enemy E3 = new Enemy("Curtis");

E1.AddAtack(A1);
E1.AddAtack(A2);
E1.AddAtack(A3);

E2.AddAtack(A1);
E2.AddAtack(A2);
E2.AddAtack(A3);

E3.AddAtack(A1);
E3.AddAtack(A2);
E3.AddAtack(A3);


E1.RandomAttack();
// E1.showAttacks();
// E2.showAttacks();
// E3.showAttacks();
