using Rpg;
using Rpg.ItemClasses;

namespace Rpg.Game.Player;

public static class PlayerCommands
{
  // Methods
  public static string ExecCommand(string inCommand, Player player)
  {
    if ( validCommands.ContainsKey(inCommand) )
    {
      return validCommands[inCommand];
    }
    
    return $"Command {inCommand} not found.";
  }
  
  // Fields
  public static Dictionary<string, string> validCommands = new Dictionary<string, string>()
  {
    { "attack", "1"},
    { "rest", "0"}
  };
}

/* List of commands to implement
COMBAT
- Attack
- Train
- Sheath/Unsheath
- Throw

SHOP
- Buy
- Sell

MAP
- Current room
- Current spawn room
- Map of the land
- Moving commands
- Search room

ITEM
- Inventory
- Equip/Dequip
- Consume item
- Use item
- Drop item

ACTION
- Talk (npcs)
- Rest
- Inspect (item)
- Open (chests, containers, etc.)
- Loot (bodies)

PLAYER
- Current xp
- Current level
- Current defense
- Current health
- Items held

SOCIAL
- Emote
- Yell (all players)
- Message
- Friend
- Duel
- Attack

MISC
- Help
- Change password
*/
