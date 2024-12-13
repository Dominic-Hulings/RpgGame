namespace Rpg.Server.ServerData;

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
      File.WriteAllText($"{GameBasePath}/Server/ServerData/Data/paths.txt", "");
      using StreamWriter sw = new StreamWriter($"{GameBasePath}/Server/ServerData/Data/paths.txt");
      {
        sw.WriteLine($"BASE{GameBasePath}");
        sw.WriteLine($"PATH{GameBasePath}/Server/ServerData/Data/paths.txt");
        sw.WriteLine($"PLYR{GameBasePath}/Server/ServerData/Data/players.txt");
        sw.WriteLine($"WEPN{GameBasePath}/Game/Item/weapons.txt");
        sw.WriteLine($"WEAR{GameBasePath}/Game/Item/wearables.txt");
        sw.WriteLine($"CONS{GameBasePath}/Game/Item/consumables.txt");
      }
    }
    
    catch
    {
      Console.WriteLine("Error: File not found");
    }
  }
  
  public static string GetPath( string pathQuery )
  {
    using StreamReader sr = new StreamReader($"{GameBasePath}/Server/ServerData/Data/paths.txt");
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