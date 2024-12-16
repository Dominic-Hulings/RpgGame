using Rpg.TerminalUtils;

namespace Rpg.Server.ServerData;

public static class ServerConfig
{
  public static void StartConfig()
  {
    bool exitFlag = false;
    int index = 1;
    
    using StreamReader sr = new StreamReader(Paths.GetPath("CONF"));
    {
      while (!exitFlag)
      {
        Console.Clear();
        int line = 0;
        
        while ( sr.Peek() >= 0 )
        {
          line++;
          string lineRead = sr.ReadLine();
          string lineToPrint = "";
          
          for ( int i = 0; i < lineRead.Length; i++ )
          {
            if ( lineRead[i] == '[' )
            {
              char tf = (lineRead[i + 1] == '0') ? tf = ' ' : tf = '*';
              lineToPrint += $"[{tf}]";
            }
            
            lineToPrint += lineRead[i];
          }
          
          Terminal.DisplayLine("")
        }

        var key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.UpArrow)
        {
          index--;
        }

        else if (key == ConsoleKey.DownArrow)
        {
          index++;
        }

        else if (key == ConsoleKey.Enter)
        {
          break;
        }
      }
    }
    
  }
  
  
}