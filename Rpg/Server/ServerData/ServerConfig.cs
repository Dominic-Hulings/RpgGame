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
      }

      else if (key == ConsoleKey.DownArrow)
      {
        index++;
      }

      else if (key == ConsoleKey.Enter)
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
    }
    
  }
  
  
}