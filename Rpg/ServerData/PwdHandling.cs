namespace Rpg.ServerData;

public static class PwdHandling
{
  public static bool isValidPwd ( string inPassword )
  {
    Console.WriteLine("Checking if password is valid");
    
    if (!inPassword.Contains('*'))
    {
      Console.WriteLine("Password is not valid, please try again.");
      return false;
    }
    
    return true;
  }
  
  public static int Store ( string inPassword )
  {
    var rand = new Random();
    
    while (true)
    {
      string userId = "";
      for (int i = 0; i < 5; i++)
      {
        userId += rand.Next().ToString();
      }
      
      return int.Parse(userId);
    }
    
  }
}