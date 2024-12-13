namespace Rpg.Game.Item;

public class FACConsumable : BaseItem
{
  private FACConsumable()
  {
    this.isWearable = false;
    this.isWieldable = false;
    this.isConsumable = true;
  }
}