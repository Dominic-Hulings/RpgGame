namespace Rpg.Game.Item;

public abstract class BaseItem
{
  // Fields
  public string Name = "";
  public string Description = "";
  
  public bool isWearable;
  public bool isWieldable;
  public bool isConsumable;
}