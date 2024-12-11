using System.Security.Cryptography;
using System.Text;

namespace Rpg.ServerData;

public static class Passwords
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
  
  public static void ResetPlayersFile()
  {
    File.WriteAllText(Paths.GetPath("PLYR"), "");
  }
  
  public static void Store ( string inPassword )
  {
    if (!isValidPwd(inPassword))
    {
      Console.WriteLine("Not a avlid password");
      return;
    }
    var rand = new Random();
    
    while (true)
    {
      string userId = "ID";
      bool idExists = false;
      
      for (int i = 0; i < 6; i++)
      {
        userId += rand.Next(9).ToString()[0];
      }
      
      using StreamReader sr = new StreamReader(Paths.GetPath("PLYR"));
      {
        char[] buffer = ['A', 'A', 'A', 'A', 'A', 'A', 'A',];
        
        while (sr.Peek() >= 0)
        {
          sr.ReadBlock(buffer, 0, 7);
          string existingId = new string(buffer);
        
          if ( userId == existingId )
          {
            idExists = true;
            break;
          }
        
          sr.ReadLine();
        }
      }
      
      if (!idExists)
      {
        using (StreamWriter sw = File.AppendText(Paths.GetPath("PLYR")))
        {
          SHA256 sha256 = SHA256.Create();
          byte[] pwd = Encoding.UTF8.GetBytes(inPassword);
          byte[] pwdHash = sha256.ComputeHash(pwd);
          
          sw.WriteLine(userId);
          sw.WriteLine(Encoding.UTF8.GetString(pwdHash));
          
          break;
        }
      }
    }
  }
}