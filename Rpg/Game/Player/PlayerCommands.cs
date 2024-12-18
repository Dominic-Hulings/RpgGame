using Rpg;
using Rpg.Game;
using Rpg.Server.ServerData;
using Rpg.TerminalUtils;

namespace Rpg.Game.Player;

public class PlayerCommands
{
  // Fields
  public Dictionary<string, Delegate> validCommands = new Dictionary<string, Delegate>()
  {
    { "exit", new Func<int, int>(FUNCExit) },
    { "help", new Func<int, int>(FUNCHelp) },
    { "login", new Func<int, int>(FUNCLogin) }
  };
  
  private BasePlayer? Player = null;
  private int retVal = 0;
  
  // Methods
  public int ExecCommand(string inCommand, BasePlayer? inPlayer)
  {
    if ( validCommands.ContainsKey(inCommand.ToLower()) )
    {
      validCommands[inCommand].DynamicInvoke("");
    }
    
    Terminal.DisplayLine($"Command {inCommand} not found.", "Red");
    return 0;
  }
  
  //!
  //! COMMAND FUNCTIONS END
  //!
  
  public static int FUNCExit(int x = 0)
  {
    Terminal.DisplayLine("Exiting game...", "Yellow");
    Environment.Exit(1);
    return x;
  }
  
  public static int FUNCHelp(int inCmd = 0)
  {
    Console.WriteLine("Help executed");
    return inCmd;
  }
  
  public static int FUNCLogin(int x = 0)
  {
    Player = Passwords.LoginQuery();
    
    if ( Player == null )
    {
      Terminal.DisplayLine("Login failed.", "Red");
    }
    
    return x;
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
