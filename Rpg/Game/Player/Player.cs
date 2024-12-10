using Rpg.ItemClasses;

namespace Rpg.Game.Player;

public class Player
{
  // Constructor
  public Player(string inName, string inRace, string inClass, bool inIsFemale, int inHealth)
  {
    Name = inName;
    Race = inRace;
    Health = MaxHealth = inHealth;
    Class = inClass;
    isFemale = inIsFemale;
  }
  // Fields & Properties
  public int Health; //? Minimum health is probably going to be 50
  public int Level { get; private set; } = 1;
  private int MaxHealth;
  private int Defense = 0; //? Minimum defense is probably going to be 0
  private int Mana = 0;
  private int CurrentExperience = 0;
  private int ExperienceToLevelUp = 50;
  private int playerId;
  public string Name { get; }
  public string Race { get; }
  public string Class;
  public string CurrentRoom { get; set; } = "";
  private string SpawnRoom { get; set; } = "";
  public bool isFemale;
  public bool isInCombat;
  private List<Item> Inventory = new List<Item>(); //? Minimum inventory is a torch
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