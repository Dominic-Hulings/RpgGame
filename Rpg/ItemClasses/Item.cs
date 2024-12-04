namespace Rpg.ItemClasses;

public abstract class Item
{
  // Fields
  public required string itemName;
  public required string itemDescription;
  public required bool isWearable;
  public required bool isWieldable;
  public required bool isConsumable;
}