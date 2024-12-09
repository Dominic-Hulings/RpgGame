using Rpg.Game;
using Rpg.ItemClasses;

Console.WriteLine("Welcome to Dominic's Rpg MUD thingy! I hope you enjoy :)");
Console.WriteLine("Would you like to create a new character? y/n");
if (Console.ReadLine().ToLower() == "y")
{
  CreateCharacter CC = new CreateCharacter();
  CC.Start();
}