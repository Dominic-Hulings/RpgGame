using Rpg.ItemClasses;

namespace Rpg;

public class Player
{
  // Fields & Properties
  public int Health { get; set; }
  public int MaxHealth;
  public int Defense { get; set; }
  public int Experience { get; set; }
  private int ExperienceToLevelUp { get; set; }
  public int Level { get; set; }
  public static string? Name;
  public static string? Race;
  public string? CurrentRoom { get; set; }
  public string? SpawnRoom { get; set; }
  public bool isFemale;
  public List<Item> Inventory = new List<Item>();
  public Item? ItemInLeftHand { get; set; }
  public Item? ItemInRightHand { get; set; }
  
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
    Experience += xpGained;
    if ( Experience >= ExperienceToLevelUp )
    {
      LevelUp();
    }
  }
  
  private void LoseXp ( int xpLost )
  {
    Experience -= xpLost;
  }
  
  private void LevelUp ()
  {
    Experience -= ExperienceToLevelUp;
    ExperienceToLevelUp += 100;
    Level += 1;
  }
}