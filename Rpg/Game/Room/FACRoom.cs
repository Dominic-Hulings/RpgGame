using Rpg.Server.ServerData;

namespace Rpg.Game.Room;

public class FACRoom : BaseRoom
{
  public FACRoom ( string roomName )
  {
    using StreamReader sr = new StreamReader(Paths.GetPath("ROOM"));
    {
      bool roomFound = false;
      while ( sr.Peek() >= 0 )
      {
        string? currentLine = sr.ReadLine();
        if ( currentLine == roomName )
        {
          roomFound = true;
          this.Name = roomName.Remove(0, 4);
          break;
        }
      }
      
      if(!roomFound)
      {
        Console.WriteLine($"Room '{roomName}' was not found in rooms.txt");
        return;
      }
      
      this.Description = sr.ReadLine();
      this.Temp = int.Parse(sr.ReadLine());
      this.IsOutside = bool.Parse(sr.ReadLine());
      this.IsLit = bool.Parse(sr.ReadLine());
      
      while (true)
      {
        string? nextLine = sr.ReadLine();
        
        if ( nextLine == "!")
        {
          break;
        }
        
        DirectionsToExit.Add(nextLine, sr.ReadLine());
      }
    }
  }
}