using Rpg.Game.Player;

namespace Rpg.TerminalUtils;

public class PlayerTerminal
{
  private PlayerCommands Commands = new PlayerCommands();
  public BasePlayer? Player = null;
  
  public void AcceptInput()
  {
    Console.Write("Input: ");
    string input = Console.ReadLine();
    Commands.ExecCommand(input, Player);
  }
}