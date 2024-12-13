using Rpg.Game;
using Rpg.Server.ServerData;

namespace Rpg.Game.Player
{
  public static class CreateCharacter
  {
    // Methods
    public static BasePlayer New ()
    {
      // Base stats and beginning
      int Health = 50;
      int Experience = 0;
      int ExperienceToLevelUp = 50;
      int Level = 1;
      bool isFemale;
      string Name = "";
      string Race = "";
      string Class = "";
      
      Console.WriteLine("Welcome to character creation. Follow the prompts to create a character!");
      
      while (true)
      {
        Console.WriteLine("Are you a male (m) or female (f)?");
        Console.WriteLine("*This will not effect gameplay.");
        
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
      while (true)
      {
        Console.WriteLine();
        Console.WriteLine("What is your name, traveller?");
      
        Name = Console.ReadLine();
        
        if (Passwords.IdQuery(Name) == 0)
        {
          Console.WriteLine();
          break;
        }
        
        Console.WriteLine("That Name already exists, please enter a different name.");
      }
      
      // Race
      while ( true )
      {
        Console.WriteLine("Now it's time to choose a race! Different races come with different perks.");
        Console.WriteLine("The races you can choose from include:");
        string[] validRaces = ["human", "elf", "dwarf", "orc", "gnome", "duegrar"];
        
        Console.WriteLine("|  Human  || Very versatile in nature, able to adapt well to their surroundings.");
        Console.WriteLine("|   Elf   || Bound from birth by the Mythra, they are naturals when it comes to magic.");
        Console.WriteLine("|  Dwarf  || Raised from the depths of Kaglemros, metalworking runs in thier blood.");
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
          Console.WriteLine($"The race you chose was a {Race}!");
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
        Console.WriteLine("| Spellcaster || Relies on spells to win a fight.");
        Console.WriteLine("|    Thief    || Relies on deception to win a fight.");
        
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
          Console.WriteLine($"The class you chose was a {Class}!");
          break;
        }
        
        Console.WriteLine("Input not recognized, please type a valid class from the list.");
      }
      
      // Password
      while (true)
      {
        Console.WriteLine($"Please create a password for {Name}.");
        Console.WriteLine("*This is how you will re-access your character if you log out.");
        Console.WriteLine("**You will need to remember your Characters name AND password!");
        Console.WriteLine();
        Console.WriteLine("Your password must: ");
        Console.WriteLine("Minimum length of 7 characters");
        Console.WriteLine("Contain at least one asterisk (*)");
        Console.WriteLine("Contain NO spaces, slashes, or any type of parentheses");
        
        string inPwd = Passwords.HideInput();
        if (!Passwords.isValidPwd(inPwd))
        {
          Console.WriteLine("Your password was invalid.\n");
          continue;
        }
        
        Console.WriteLine("Your password is valid, please type it one more time to confirm.");
        string confirmPwd = Passwords.HideInput();
        if ( inPwd != confirmPwd )
        {
          Console.WriteLine("Your password's did not match, please try again.\n");
          continue;
        }
        
        Console.WriteLine("Your password has been successfully set!");
        Passwords.Store( Name, inPwd );
        break;
      }
      Console.WriteLine($"BasePlayer {Name} has been created sucessfully!");
      return new BasePlayer(Name, Race, Class, isFemale, Health);
    }
  }
}

