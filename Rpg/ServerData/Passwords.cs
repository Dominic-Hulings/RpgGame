using System.Security.Cryptography;
using System.Text;

namespace Rpg.ServerData;

public static class Passwords
{
  public static bool isValidPwd ( string inPassword ) // Checks if an inputted password is valid before storing
  {
    if (!inPassword.Contains('*'))
    {
      return false;
    }
    
    return true;
  }
  
  public static string HideInput(string prompt = "Password: ") // For hiding the password from the user ("password" => "********")
  {
    Console.Write(prompt);
    string password = null;
    
    while (true)
    {
      var key = System.Console.ReadKey(true);
      if (key.Key == ConsoleKey.Enter) { break; }
      Console.Write('*');
      password += key.KeyChar;
    }
    
    return password;
  }
  
  public static bool IdExists( string nameQuery ) // Checks if a user id already exists
  {
    using StreamReader sr = new StreamReader(Paths.GetPath("PLYR"));
    {
      while (sr.Peek() >= 0)
      {
        if ( sr.ReadLine() == $"ID{nameQuery}" )
        {
            return true;
        }
      }
    }
    
    return false;
  }
  
  public static void ResetPlayersFile() // Deletes all data in players.txt
  {
    File.WriteAllText(Paths.GetPath("PLYR"), "");
  }
  
  public static void Store ( string inUserId, string inPassword ) // Stores a hashed user id along with a hashed password (SHA256)
  {
    if (!isValidPwd(inPassword))
    {
      Console.WriteLine("Not a avlid password");
      return;
    }
    
    var rand = new Random();
    
    while (true)
    {
      string userId = inUserId;
      
      if (!IdExists(inUserId))
      {
        using (StreamWriter sw = File.AppendText(Paths.GetPath("PLYR")))
        {
          SHA256 sha256 = SHA256.Create();
          byte[] pwd = Encoding.UTF8.GetBytes(inPassword);
          byte[] id = Encoding.UTF8.GetBytes(inUserId);
          byte[] pwdHash = sha256.ComputeHash(pwd); // TODO: Add a salt that can be set by admin
          byte[] idHash = sha256.ComputeHash(id); // TODO: Add a salt that can be set by admin
          
          sw.WriteLine(Encoding.UTF8.GetString(idHash));
          sw.WriteLine(Encoding.UTF8.GetString(pwdHash));
          
          break;
        }
      }
      
      Console.WriteLine($"The name: {inUserId} has already been taken");
      return;
    }
    
    
  }
  
}