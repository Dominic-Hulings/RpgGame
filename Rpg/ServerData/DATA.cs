using Rpg.Game.Player;

namespace Rpg.ServerData;

internal struct PlayerNode
{
  private int userID;
  private string pwd;
  private Player PlayerObj;
}

public class DATA
{
  List<PlayerNode> playerData = new List<PlayerNode>();
}