namespace Rpg.Game.Item;

public class FACWearable : BaseItem
{
  private FACWearable()
  {
    this.isWearable = true;
    this.isWieldable = false;
    this.isConsumable = false;
  }
}