using Rpg.TerminalUtils;

namespace Rpg.Server.ServerData;

public static class ServerConfig
{
  public static void StartConfig()
  {
    bool exitFlag = false;
    int index = 1;
    
    while (!exitFlag) 
    { 
      Console.Clear();
      
      int line = 0;
      List<string> fileContents = new List<string>();
      
      using StreamReader sr = new StreamReader(Paths.GetPath("CONF"));
      {
        Terminal.DisplayLine("Use the arrows to navigate, enter to toggle vales, and space to quit");
        
        while (sr.Peek() >= 0)
        {
          line++;
          string lineRead = sr.ReadLine();
          fileContents.Add(lineRead);
          string lineToPrint = "";

          for (int i = 0; i < lineRead.Length; i++)
          {
            if (lineRead[i] == '[')
            {
              char tf = (lineRead[i + 1] == '0') ? tf = ' ' : tf = '*';
              lineToPrint += $"[{tf}]";
              if (line == index)
              {
                lineToPrint += '<';
              }

              break;
            }

            lineToPrint += lineRead[i];
          }

          Terminal.DisplayLine(lineToPrint);
        }
      }

      var key = Console.ReadKey(true).Key;

      if (key == ConsoleKey.UpArrow)
      { 
        index--;
        
        if ( index == 0 )
        {
          index = line;
        }
      }

      else if (key == ConsoleKey.DownArrow)
      {
        index++;
        
        if ( index == (line + 1))
        {
          index = 1;
        }
      }

      else if (key == ConsoleKey.Enter) //* Too much code to just change the value to its inverse
      {
        using StreamWriter sw = new StreamWriter(Paths.GetPath("CONF"), false);
        {
          int i = 1;
          
          foreach ( string x in fileContents )
          {
            if ( i != index )
            {
              sw.WriteLine(x);
              i++;
              continue;
            }
            
            string lineToPrint = "";
            
            for (int l = 0; l < x.Length; l++)
            {
              if (x[l] == '[')
              {
                char tf2 = (x[l + 1] == '0') ? tf2 = '1' : tf2 = '0';
                lineToPrint += $"[{tf2}]";
                break;
              }

              lineToPrint += x[l];
            }
            
            i++;
            sw.WriteLine(lineToPrint);
          }
        }
        
        
      }
      
      else if (key == ConsoleKey.Spacebar)
      {
        break;
      }
      
    }
    
    Console.Clear();
    Terminal.DisplayLine("Config saved!", "Green");
  }
  
  
}