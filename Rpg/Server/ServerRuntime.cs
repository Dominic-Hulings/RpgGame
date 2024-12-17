using Rpg.Game.Player;
using Rpg.Game.Room;
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
    
    while (true)  //* Asks if user wants to start inital config
    {             //* if yes then bring up config editor menu, if no then quit app
      
      Terminal.DisplayLine("Start initial configuration? y/n", "Cyan");
      
      string? input = Console.ReadLine();
      
      if ( input?.ToLower() == "y" )
      {
        Terminal.DisplayLine("Starting configuration scripts...", "Orange");
        Terminal.DisplayLine("Adding path variables to paths.txt...", "Orange");
        Paths.SetAll();
        Terminal.DisplayLine("Paths added!", "Green");
        ServerConfig.StartConfig();
        break;
      }
      
      if ( input?.ToLower() == "n" )
      {
        Console.WriteLine("Closing application.");
        Environment.Exit(1);
      }
      
      Console.WriteLine("Input not recognized, please enter 'y' or 'n'.");
    }
    
    while (true) //* Checks if user is making a server or a singleplayer world
    {
      Terminal.DisplayLine("Will you be creating a server or playing singleplayer?", "Cyan");
      Terminal.DisplayLine("Type 1 for singleplayer and 2 for server", "Cyan");
      
      string? input = Console.ReadLine();
      
      if ( input?.ToLower() == "1")
      {
        Console.WriteLine("You chose single player!");
        Console.WriteLine();
        Terminal.DisplayLine("Starting character create...", "Orange");
        CreateCharacter.New();
        
      }
      
      else if ( input?.ToLower() == "2")
      {
        Console.WriteLine("TODO");
        return;
      }
      
      Console.WriteLine("Input not recognized, please try again.");
      Console.WriteLine();
    }
  }
  
  public static void Start()
  {
    foreach (FACRoom x in RoomCommands.CreateAll())
    {
      Console.WriteLine(x.Name);
      Console.WriteLine(x.Description);
      Console.WriteLine(x.Temp);
      Console.WriteLine(x.IsOutside);
      Console.WriteLine(x.IsLit);
      
      foreach ( var item in x.DirectionsToExit )
      {
        Console.WriteLine(item.Key);
        Console.WriteLine(item.Value);
      }
      
      Console.WriteLine();
      Console.WriteLine();
    }
  }
  
  public static void Pause()
  {
    
  }
  
  public static void ShutDown()
  {
    
  }
  
}