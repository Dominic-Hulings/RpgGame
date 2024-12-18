using Rpg;
using Rpg.Game;
using Rpg.TerminalUtils;

namespace Rpg.Game.Player;

public static class PlayerCommands
{
  // Fields
  public static Dictionary<string, Delegate> validCommands = new Dictionary<string, Delegate>()
  {
    { "exit", new Func<string, string>(FUNCExit) },
    { "help", new Func<string, string>(FUNCHelp) }
  };
  
  // Methods
  public static void ExecCommand(string inCommand)
  {
    if ( validCommands.ContainsKey(inCommand.ToLower()) )
    {
      validCommands[inCommand].DynamicInvoke("");
      return;
    }
    
    Terminal.DisplayLine($"Command {inCommand} not found.", "Red");
  }
  
  //!
  //! COMMAND FUNCTIONS END
  //!
  
  private static string FUNCExit(string x = "")
  {
    Terminal.DisplayLine("Exiting game...", "Yellow");
    Environment.Exit(1);
    return x;
  }
  
  private static string FUNCHelp(string inCmd = "GEN")
  {
    Console.WriteLine("Help executed");
    return inCmd;
  }
  
  //!
  //! COMMAND FUNCTIONS END
  //!
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
