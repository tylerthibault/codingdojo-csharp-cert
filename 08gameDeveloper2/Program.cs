
// SETUP ******************

Attack Shoot = new Attack("Shooting", 20);
Attack KnifeThrow = new Attack("Knife Throwing", 15);

RangedFighter Ranger = new RangedFighter("Tyler");

Ranger.AddAtack(Shoot);
Ranger.AddAtack(KnifeThrow);


Attack Punch = new Attack("Punching",20);
Attack Kick = new Attack("Kicking", 15);
Attack Tackle = new Attack("Tackling", 25);

MeleeFighter Fighter = new MeleeFighter("Kendal");

Fighter.AddAtack(Punch);
Fighter.AddAtack(Kick);
Fighter.AddAtack(Tackle);


Attack Fireball = new Attack("Fireballing", 25);
Attack Shield = new Attack("Shielding", 0);
Attack StaffStrike = new Attack("Staff Striking", 15);

MagicCaster Magicer = new MagicCaster("Joe");

Magicer.AddAtack(Fireball);
Magicer.AddAtack(Shield);
Magicer.AddAtack(StaffStrike);


// ACTIONS ***********************

Fighter.RandomAttack();
Fighter.Rage();

Ranger.RandomAttack();
Ranger.Dash();
Ranger.RandomAttack();

Magicer.RandomAttack();
Magicer.Heal(Fighter);