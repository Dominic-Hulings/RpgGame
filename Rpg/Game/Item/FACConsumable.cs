using Rpg.Server.ServerData;

namespace Rpg.Game.Item;

public class FACConsumable : BaseItem
{
  public FACConsumable( string itemName )
  {
    this.isWearable = false;
    this.isWieldable = false;
    this.isConsumable = true;
    
    using StreamReader sr = new StreamReader(Paths.GetPath("CONS"));
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
      this.effect = sr.ReadLine();
    }
  }
  
  // Fields
  public string effect;
}