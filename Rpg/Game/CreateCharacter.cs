using Rpg;
using Rpg.ItemClasses;

namespace Rpg.Game
{
  public class CreateCharacter
  {
    // Properties
    public int Health { get; set; }
    public int MaxHealth;
    public int Defense { get; set; }
    public int Experience { get; set; }
    private int ExperienceToLevelUp { get; set; }
    public int Level { get; set; }
    public static string? Name;
    public static string? Race;
    public string? CurrentRoom { get; set; }
    public string? SpawnRoom { get; set; }
    public static bool isFemale;
    public List<Item> Inventory = new List<Item>();
    
    // Methods
    public void Start ()
    {
      // Base stats and beginning
      Health = MaxHealth = 25;
      Experience = 0;
      ExperienceToLevelUp = 50;
      Level = 1;
      
      Console.WriteLine("Welcome to character creation.");
      Console.WriteLine("Are you a male (m) or female (f)?");
      Console.WriteLine("*This will not effect gameplay");
      
      // Gender
      if (Console.ReadLine().ToLower() == "m")
      {
        isFemale = false;
      }
      
      else if (Console.ReadLine().ToLower() == "f")
      {
        isFemale = true;
      }
      
      else
      {
        Console.WriteLine("Input not recognized, defaulting to male.");
        isFemale = false;
      }
      
      // Name
      Console.WriteLine("What is your name, traveller?");
      
      Name = Console.ReadLine();
      
      // Race
      while ( true )
      {
        Console.WriteLine("Now it's time to choose a race! Different races come with different perks.");
        Console.WriteLine("The races you can choose from include:");
        string[] validRaces = {"human", "elf", "dwarf", "orc", "gnome", "duegrar"};
        
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
          
          else
          {
            continue;
          }
        }
        
        if (!isValid)
        {
          Console.WriteLine("Input not recognized, please type a valid race from the list.");
          continue;
        }
        
        
        
      }
    }
  }
}

