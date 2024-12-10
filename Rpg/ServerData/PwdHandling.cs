namespace Rpg.ServerData;

public static class PwdHandling
{
  public static int Store ( string inPassword )
  {
    Console.WriteLine("Checking if password is valid");
    
    if (!inPassword.Contains('*'))
    {
      Console.WriteLine("Password is not valid, please try again.");
      return 0;
    }
    
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