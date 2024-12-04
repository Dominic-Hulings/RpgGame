using Rpg.Game;
using Rpg.ItemClasses;

Console.WriteLine("Welcome to Dominic's Rpg MUD thingy! I hope you enjoy :)\n");
Console.WriteLine("Would you like to create a new character? y/n\n");
if (Console.ReadLine() == "y")
{
  CreateCharacter.Start();
}