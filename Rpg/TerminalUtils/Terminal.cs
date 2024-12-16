namespace Rpg.TerminalUtils;

public static class Terminal
{
  public static void DisplayLine ( string inText, string inColor = "DEFAULT")
  {
    ConsoleColor consoleColor = ConsoleColor.White;
    
    if ( inColor != "DEFAULT" )
    {
      try
      {
        consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), inColor , true);
      }
      
      catch
      {
        Console.WriteLine($"{inColor} is not a valid color.");
        return;
      }
    }
    
    Console.ForegroundColor = consoleColor;
    Console.WriteLine(inText);
    Console.ResetColor();
  }
  
  public static void Display ( string inText, string inColor = "DEFAULT")
  {
    ConsoleColor consoleColor = ConsoleColor.White;
    
    if ( inColor != "DEFAULT" )
    {
      try
      {
        consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), inColor , true);
      }
      
      catch
      {
        Console.WriteLine($"{inColor} is not a valid color.");
        return;
      }
    }
    
    Console.ForegroundColor = consoleColor;
    Console.Write(inText);
    Console.ResetColor();
  }
}