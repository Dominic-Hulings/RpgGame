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
  
  public List<Player.BasePlayer> PlayersInRoom = new List<Player.BasePlayer>();
  public List<BaseNpc> NPCsInRoom = new List<BaseNpc>();
  public List<Corpse> CorpsesInRoom  = new List<Corpse>();
  public List<Item.BaseItem> ItemsInRoom  = new List<Item.BaseItem>();
  
  public Dictionary<string, string> DirectionsToExit = new Dictionary<string, string>();
  //         Direction^       ^Room
}