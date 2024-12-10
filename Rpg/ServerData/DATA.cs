using Rpg.Game.Player;

namespace Rpg.ServerData;

internal struct PlayerNode
{
  private string pwd;
  private Player playerObj;
  
  public PlayerNode(string inPwd, Player inPlayerObj)
  {
    pwd = inPwd;
    playerObj = inPlayerObj;
  }
}

public class DATA
{
  Dictionary<int, PlayerNode> playerData;
  
  public void StorePlayerNode(int inUserId, string inPwd, Player inPlayerObj)
  {
    PlayerNode node = new PlayerNode(inPwd, inPlayerObj);
    playerData.Add(inUserId, node);
  }
}