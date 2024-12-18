using Rpg.Game.Item;

namespace Rpg.Game.Player;

public class BasePlayer
{
  // Constructor
  public BasePlayer(string inName, string inCurrentRoom, string inSpawnRoom, string inAttributes)
  {
    Name = inName;
    CurrentRoom = inCurrentRoom;
    SpawnRoom = inSpawnRoom;
    
    string[] Attributes = inAttributes.Split(':');
    int i = 0;
    
    foreach ( string value in Attributes )
    {
      switch (i)
      {
        case 0:
          Health = int.Parse(value);
          break;
        case 1:
          Level = int.Parse(value);
          break;
        case 2:
          MaxHealth = int.Parse(value);
          break;
        case 3:
          Defense = int.Parse(value);
          break;
        case 4:
          Mana = int.Parse(value);
          break;
        case 5:
          MaxMana = int.Parse(value);
          break;
        case 6:
          CurrentExperience = int.Parse(value);
          break;
        case 7:
          ExperienceToLevelUp = int.Parse(value);
          break;
        case 8:
          Race = value;
          break;
        case 9:
          Class = value;
          break;
        case 10:
          IsFemale = bool.Parse(value);
          break;
        //* Add cases for inv items and held items
      }
      i++;
    }
  }
  
  // Fields & Properties
  public int Health; //? Minimum health is probably going to be 50
  public int Level { get; private set; } = 1;
  private int MaxHealth;
  private int Defense = 0; //? Minimum defense is probably going to be 0
  private int Mana = 0;
  private int MaxMana = 0;
  private int CurrentExperience = 0;
  private int ExperienceToLevelUp = 50;
  public string Name { get; }
  public string Race { get; }
  public string Class;
  public string CurrentRoom { get; set; } = "";
  private string SpawnRoom { get; set; } = "";
  public bool IsFemale;
  public bool isInCombat;
  private List<Item.BaseItem> Inventory = new List<Item.BaseItem>(); //? Minimum inventory is a torch
  public Item.BaseItem? ItemInLeftHand { get; set; }
  public Item.BaseItem? ItemInRightHand { get; set; }
  
  // Methods
  public void RecieveDamage ( int damageRecieved )
  {
    Health -= damageRecieved;
    if ( Health <= 0 )
    {
      IsDead();
    }
  }
  
  private void IsDead ()
  {
    LoseXp(50);
    CurrentRoom = SpawnRoom;
  }
  
  private void GainXp ( int xpGained )
  {
    CurrentExperience += xpGained;
    if ( CurrentExperience >= ExperienceToLevelUp )
    {
      LevelUp();
    }
  }
  
  private void LoseXp ( int xpLost )
  {
    CurrentExperience -= xpLost;
  }
  
  private void LevelUp ()
  {
    CurrentExperience -= ExperienceToLevelUp;
    ExperienceToLevelUp += 100;
    Level += 1;
  }
}