using Rpg.Game.Item;
using Rpg.Game.NPC;
using Rpg.Game.Player;

namespace Rpg.Game.Room;

public abstract class BaseRoom
{
  public string Name = "";
  public string Description = "";
  
  public int Temp = 0;
  
  public bool IsOutside;
  public bool IsLit;
  
  public List<Player.BasePlayer>? PlayersInRoom;
  public List<BaseNpc>? NPCsInRoom;
  public List<Corpse>? CorpsesInRoom;
  public List<Item.BaseItem>? ItemsInRoom;
  
  public Dictionary<string, string>? DirectionsToExit;
  //   Direction^       ^Exit description
}