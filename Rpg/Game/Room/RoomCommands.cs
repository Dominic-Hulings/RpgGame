using Rpg.Server.ServerData;

namespace Rpg.Game.Room;

public static class RoomCommands
{
  public static List<FACRoom> CreateAll()
  {
    List<string> RoomNames = new List<string>();
    
    using StreamReader sr = new StreamReader(Paths.GetPath("ROOM"));
    {
      while ( sr.Peek() >= 0 )
      {
        if ( sr.ReadLine() == "!")
        {
          string y = sr.ReadLine();
          
          if ( y != "ENDOFFILE" )
          {
            RoomNames.Add(y);
          }
        }
      }
    }
    
    List<FACRoom> Rooms = new List<FACRoom>();
    
    foreach ( string room in RoomNames )
    {
      Rooms.Add(new FACRoom(room));
    }
    
    return Rooms;
  }
}