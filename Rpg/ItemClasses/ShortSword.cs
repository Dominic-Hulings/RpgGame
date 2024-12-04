namespace Rpg.ItemClasses;

public class ShortSword : Weapon
{
  // Constructor
  public ShortSword()
  {
    this.itemName = "Short Sword";
    this.itemDescription = "This steel-forged short sword glistens at the hilt, beckoning for adventure\n";
    this.atkDamage = 8;
    this.atkType = "Melee";
    this.isTwoHanded = false;
  }
}