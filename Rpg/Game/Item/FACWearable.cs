using Rpg.Server.ServerData;

namespace Rpg.Game.Item;

public class FACWearable : BaseItem
{
  public FACWearable( string itemName )
  {
    this.isWearable = true;
    this.isWieldable = false;
    this.isConsumable = false;
    
    using StreamReader sr = new StreamReader(Paths.GetPath("WEAR"));
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
        Console.WriteLine($"Wearable {itemName} was not found in wearable.txt");
        return;
      }
      
      this.Description = sr.ReadLine();
      this.defensePts = int.Parse(sr.ReadLine());
      this.wornOn = int.Parse(sr.ReadLine());
    }

  }
  
  public int defensePts;
  public int wornOn;
}