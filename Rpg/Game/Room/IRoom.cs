using Rpg.Game.Item;
using Rpg.Game.NPC;
using Rpg.Game.Player;

namespace Rpg.Game.Room;

public interface IRoom
{
  string RoomName { get; }
  string RoomDescription { get; }
  
  int temp { get; set; }
  
  bool IsOutside { get; }
  bool IsLit { get; set; }
  
  List<Player.BasePlayer> PlayersInRoom { get; set; }
  List<BaseNpc> NPCsInRoom { get; set; }
  List<Corpse> CorpsesInRoom { get; set; }
  List<Item.BaseItem> ItemsInRoom { get; set; }
  
  Dictionary<string, string> DirectionsToExit { get; }
  //   Direction^       ^Exit description
}