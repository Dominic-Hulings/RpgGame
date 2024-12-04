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
  public int? atkDamage;
  public string? atkType;
  public bool? isTwoHanded;
}