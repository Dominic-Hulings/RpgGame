using Rpg.Server.ServerData;

namespace Rpg.Game.Item;

public class FACWeapon : BaseItem
{
  // Constructor
  public FACWeapon( string itemName )
  {
    this.isWearable = false;
    this.isWieldable = true;
    this.isConsumable = false;
    
    using StreamReader sr = new StreamReader(Paths.GetPath("WEPN"));
    {
      bool itemFound = false;
      while ( sr.Peek() >= 0 )
      {
        string? currentLine = sr.ReadLine();
        if ( currentLine == itemName)
        {
          itemFound = true;
          this.Name = currentLine;
          break;
        }
      }
      
      if (!itemFound)
      {
        Console.WriteLine($"Weapon {itemName} was not found in weapons.txt");
        return;
      }
      
      this.Description = sr.ReadLine();
      this.atkDamage = int.Parse(sr.ReadLine());
      this.atkType = sr.ReadLine();
    }
    
  }
  
  // Fields
  public int atkDamage;
  public string atkType;
  public bool isTwoHanded;
}