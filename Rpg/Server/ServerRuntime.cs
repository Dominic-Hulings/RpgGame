using Rpg.Server.ServerData;
using Rpg.TerminalUtils;

namespace Rpg.Server;

public static class ServerRuntime
{
  public static void InitialStartup()
  {
    Console.WriteLine("Thank you for choosing my MUD to play!");
    Console.WriteLine("I had a lot of fun creating it and I hope you enjoy!");
    Console.WriteLine("- Dominic :)");
    Console.WriteLine();
    
    Console.WriteLine("Now it is time to create the games configuration files.");
    Terminal.DisplayLine("Please follow the prompts carefully to configure and start your game!", "Red");
    Console.WriteLine("** P.S.: If you encounter any issues/glitches/bugs then please let me know on my github **");
    Console.WriteLine();
    
    while (true)
    {
      Terminal.DisplayLine("Start initial configuration? y/n", "Cyan");
      
      string? input = Console.ReadLine();
      
      if ( input?.ToLower() == "y" )
      {
        Console.WriteLine("Starting configuration scripts.");
        break;
      }
      
      if ( input?.ToLower() == "n" )
      {
        Console.WriteLine("Closing application.");
        Environment.Exit(1);
      }
      
      Console.WriteLine("Input not recognized, please enter 'y' or 'n'.");
    }
    
  }
  
  public static void Start()
  {
    
  }
  
  public static void Pause()
  {
    
  }
  
  public static void ShutDown()
  {
    
  }
  
}