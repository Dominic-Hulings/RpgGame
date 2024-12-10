using Rpg.ItemClasses;

namespace Rpg.Game.Player
{
  public class CreateCharacter
  {
    // Fields
    private int Health;
    private int Defense;
    private int Experience;
    private int ExperienceToLevelUp;
    private int Level;
    private string Name;
    private string Race;
    private string Class;
    private string? CurrentRoom;
    private string? SpawnRoom;
    private bool isFemale;
    private List<Item> Inventory = new List<Item>();
    
    // Methods
    public Player Create ()
    {
      // Base stats and beginning
      Health = 50;
      Experience = 0;
      ExperienceToLevelUp = 50;
      Level = 1;
      
      Console.WriteLine("Welcome to character creation. Follow the prompts to create a character");
      
      while (true)
      {
        Console.WriteLine("Are you a male (m) or female (f)?");
        Console.WriteLine("*This will not effect gameplay");
        
        // Gender
        if (Console.ReadLine().ToLower() == "m")
        {
          isFemale = false;
          break;
        }
        
        else if (Console.ReadLine().ToLower() == "f")
        {
          isFemale = true;
          break;
        }
        
        else
        {
          Console.WriteLine("Input not recognized, please try again.");
          continue;
        }
      }
      
      // Name
      Console.WriteLine();
      Console.WriteLine("What is your name, traveller?");
      
      Name = Console.ReadLine();
      Console.WriteLine();
      
      // Race
      while ( true )
      {
        Console.WriteLine("Now it's time to choose a race! Different races come with different perks.");
        Console.WriteLine("The races you can choose from include:");
        string[] validRaces = ["human", "elf", "dwarf", "orc", "gnome", "duegrar"];
        
        Console.WriteLine("|  Human  || Very versatile in nature, able to adapt well to their surroundings.");
        Console.WriteLine("|   Elf   || Bound from birth by the Mythra, they are naturals when it comes to magic.");
        Console.WriteLine("|  Dwarf  || Raised from the depths of Heifler, metalworking runs in thier blood.");
        Console.WriteLine("|   Orc   || Having to fight for survival since the dawn of the third age, they are the most skilled fighters in Gilden.");
        Console.WriteLine("|  Gnome  || Due to thier small size, intelligence and wisdom was key to thier survival.");
        Console.WriteLine("| Duegrar || With most being born into poverty, thievery has become their main way of making a living.");
        
        string? raceChoice = Console.ReadLine();
        bool isValid = false;
        
        for (int i = 0; i < validRaces.Length; i++)
        {
          if (raceChoice?.ToLower() == validRaces[i])
          {
            Race = validRaces[i];
            isValid = true;
          }
        }
        
        Console.WriteLine();
        if (isValid)
        {
          Console.WriteLine($"The race you chose was a {Race}");
          break;
        }
        
        Console.WriteLine("Input not recognized, please type a valid race from the list.");
      }
      
      // Class
      while (true)
      {
        Console.WriteLine("Now it is time to choose a class, what will you choose?");
        string[] validClasses = ["fighter", "spellcaster", "thief"];
        
        Console.WriteLine("|   Fighter   || Relies on strength and skill to win a fight.");
        Console.WriteLine("| Spellcaster || Relies on spells to win a fight");
        Console.WriteLine("|    Thief    || Relies on deception to win a fight");
        
        string? classChoice = Console.ReadLine();
        bool isValid = false;
        
        for (int i = 0; i < validClasses.Length; i++)
        {
          if (classChoice?.ToLower() == validClasses[i])
          {
            Class = validClasses[i];
            isValid = true;
          }
        }
        
        Console.WriteLine();
        if (isValid)
        {
          Console.WriteLine($"The class you chose was a {Class}");
          break;
        }
        
        Console.WriteLine("Input not recognized, please type a valid class from the list.");
      }
      
      Console.WriteLine($"Player {Name} has been created sucessfully!");
      return new Player(Name, Race, Class, isFemale, Health);
    }
  }
}

