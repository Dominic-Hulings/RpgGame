using Rpg.Server.ServerData;

namespace Rpg.Game.Item;

public class FACWeapon : BaseItem
{
  // Constructor
  public FACWeapon( string weaponName )
  {
    this.isWearable = false;
    this.isWieldable = true;
    this.isConsumable = false;
    
    using StreamReader sr = new StreamReader(Paths.GetPath("WEPN"));
    {
      bool weaponFound = false;
      while ( sr.Peek() >= 0 )
      {
        string? currentLine = sr.ReadLine();
        if ( currentLine == weaponName)
        {
          weaponFound = true;
          this.Name = currentLine;
          break;
        }
      }
      
      if (!weaponFound)
      {
        Console.WriteLine($"Weapon {weaponName} was not found in weapons.txt");
        return;
      }
      
      this.Description = sr.ReadLine();
      this.atkDamage = int.Parse(sr.ReadLine());
      this.isTwoHanded = bool.Parse(sr.ReadLine());
    }
    
  }
  
  // Fields
  public int atkDamage;
  public string atkType;
  public bool isTwoHanded;
}