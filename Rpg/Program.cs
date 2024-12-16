using System.Net.Mime;
using Rpg;
using Rpg.Game.Player;
using Rpg.Server.ServerData;
using Rpg.Game.Item;
using Rpg.Game.Room;

Console.WriteLine("Welcome to Dominic's Rpg MUD thingy! I hope you enjoy :)\n");

Paths.SetAll();

FACRoom t = new FACRoom("testing");
Console.WriteLine(t.Name);
Console.WriteLine(t.Description);
Console.WriteLine(t.Temp);
Console.WriteLine(t.IsOutside);
Console.WriteLine(t.IsLit);