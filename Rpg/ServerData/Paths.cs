namespace Rpg.ServerData;

public static class Paths
{
  static string GameBasePath = Directory.GetParent(
                               Directory.GetParent(
                               Directory.GetParent(Directory.GetCurrentDirectory())
                               .FullName).FullName).FullName;
  
  public static void SetAll()
  {
    try
    {
      File.WriteAllText($"{GameBasePath}/ServerData/Data/paths.txt", "");
      using StreamWriter sw = new StreamWriter($"{GameBasePath}/ServerData/Data/paths.txt");
      {
        sw.WriteLine($"BASE{GameBasePath}");
        sw.WriteLine($"PATH{GameBasePath}/ServerData/Data/paths.txt");
        sw.WriteLine($"PLYR{GameBasePath}/ServerData/Data/players.txt");
      }
    }
    
    catch
    {
      Console.WriteLine("Error: File nout found");
    }
  }
  
  public static string GetPath( string pathQuery )
  {
    using StreamReader sr = new StreamReader($"{GameBasePath}/ServerData/Data/paths.txt");
    {
      char[] buffer = ['A', 'A', 'A', 'A'];
      while (sr.Peek() >= 0)
      {
        sr.ReadBlock(buffer, 0, 4);
        string nameOfPath = new string(buffer);
        
        if ( nameOfPath == pathQuery )
        {
          return sr.ReadLine();
        }
        
        sr.ReadLine();
      }
      
      return $"Error: Path {pathQuery} was not found";
    }
  }
}