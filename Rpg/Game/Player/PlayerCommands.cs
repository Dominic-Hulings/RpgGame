using Rpg;
using Rpg.Game;

namespace Rpg.Game.Player;

public static class PlayerCommands
{
  // Methods
  public static string ExecCommand(string inCommand)
  {
    if ( validCommands.ContainsKey(inCommand.ToLower()) )
    {
      return validCommands[inCommand];
    }
    
    return $"Command {inCommand} not found.";
  }
  
  // Fields
  public static Dictionary<string, string> validCommands = new Dictionary<string, string>()
  {
    { "exit", "Exit command executed!"},
    { "help", "Help command executed!" },
    { "attack", "Attack command executed!"},
    { "rest", "Rest command executed!"}
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
