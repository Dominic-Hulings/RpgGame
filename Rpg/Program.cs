using System.Net.Mime;
using Rpg;
using Rpg.Game.Player;
using Rpg.Server.ServerData;
using Rpg.Game.Item;

Console.WriteLine("Welcome to Dominic's Rpg MUD thingy! I hope you enjoy :)\n");

Paths.SetAll();

FACWeapon test = new FACWeapon("Steel Sword");

Console.WriteLine(test.Name);
Console.WriteLine(test.Description);
Console.WriteLine(test.isWearable);
Console.WriteLine(test.isWieldable);
Console.WriteLine(test.isConsumable);
Console.WriteLine();

FACWeapon test1 = new FACWeapon("Steel Broadsword");

Console.WriteLine(test1.Name);
Console.WriteLine(test1.Description);
Console.WriteLine(test1.isWearable);
Console.WriteLine(test1.isWieldable);
Console.WriteLine(test1.isConsumable);
Console.WriteLine();

FACWeapon test2 = new FACWeapon("Wooden Sword");

Console.WriteLine(test2.Name);
Console.WriteLine(test2.Description);
Console.WriteLine(test2.isWearable);
Console.WriteLine(test2.isWieldable);
Console.WriteLine(test2.isConsumable);