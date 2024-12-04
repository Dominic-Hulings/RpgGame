namespace Rpg.ItemClasses;

public abstract class Weapon : Item
{
  // Constructor
  protected Weapon()
  {
    this.isWearable = false;
    this.isWieldable = true;
    this.isConsumable = false;
  }
  
  // Fields
  public required int atkDamage;
  public required string atkType;
  public required bool isTwoHanded;
}