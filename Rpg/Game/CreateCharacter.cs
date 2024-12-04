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
    public int Experience;
    private int ExperienceToLevelUp { get; set; }
    public int Level { get; set; }
    public string? Name { get; set; }
    public string? CurrentRoom { get; set; }
    public string? SpawnRoom { get; set; }
    public static bool isFemale;
    public List<Item> Inventory = new List<Item>();
    
    // Methods
    public static void Start ()
    {
      // Sex
      Console.WriteLine("Welcome to character creation.\n");
      Console.WriteLine("Are you a male (m) or female (f)?\n");
      if (Console.ReadLine() == "m")
      {
        isFemale = false;
      }
      
      else if (Console.ReadLine() == "f")
      {
        isFemale = true;
      }
      
      else
      {
        Console.WriteLine("Input not recognized.\n");
      }
    }
  }
}

