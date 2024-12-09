using Rpg.Game;
using Rpg;

Console.WriteLine("Welcome to Dominic's Rpg MUD thingy! I hope you enjoy :)");
Console.WriteLine("Would you like to create a new character? y/n");
if (Console.ReadLine().ToLower() == "y")
{
  Console.WriteLine();
  CreateCharacter CC = new CreateCharacter();
  Player Dominic = CC.Create();
  Console.WriteLine(Dominic.Name);
  Console.WriteLine(Dominic.Race);
  Console.WriteLine(Dominic.Class);
  Console.WriteLine(Dominic.isFemale);
  Console.WriteLine(Dominic.Health);
}