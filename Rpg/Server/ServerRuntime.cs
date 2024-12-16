using Rpg.TerminalUtils;

namespace Rpg.Server;

public static class ServerRuntime
{
  public static void InitialStartup()
  {
    Console.WriteLine("Thank you for choosing my MUD to play!");
    Terminal.DisplayLine("I had a lot of fun creating it and I hope you enjoy!", "Red");
    Console.WriteLine("-Dominic");
    Console.WriteLine();
    
    Console.WriteLine("Now it is time to create the games configuration files.");
    
    Console.WriteLine("Please follow the prompts to configure and start your game!");
    
    Console.WriteLine("P.S.: If you encounter any issues/glitches/bugs then please let me know on my github.");
    Console.WriteLine();
    
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