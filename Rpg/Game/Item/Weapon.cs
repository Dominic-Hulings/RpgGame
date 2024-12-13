namespace Rpg.Game.Item;

public abstract class Weapon : BaseItem
{
  // Constructor
  protected Weapon()
  {
    this.isWearable = false;
    this.isWieldable = true;
    this.isConsumable = false;
  }
  
  // Fields
  public int? atkDamage;
  public string? atkType;
  public bool? isTwoHanded;
}