using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Rpg.Server.ServerData;

public static class Passwords
{
  public static bool isValidPwd( string inPassword ) // Checks if an inputted password is valid before storing
  {
    char[] requiredCharacters = ['*'];
    char[] prohibitedCharacters = [' ', '/', '\\', '{', '}', '[', ']', '(', ')'];
    
    if (inPassword.Length < 7)
    {
      return false;
    }
    
    foreach (char character in requiredCharacters)
    {
      if (!inPassword.Contains(character))
      {
        return false;
      }
    }
    
    foreach (char character in prohibitedCharacters)
    {
      if (inPassword.Contains(character))
      {
        return false;
      }
    }
    
    return true;
  }
  
  public static string HideInput( string prompt = "Password: " ) // For hiding the password from the user ("password" => "********")
  {
    Console.Write(prompt);
    string input = null;
    
    while (true)
    {
      var key = System.Console.ReadKey(true);
      if (key.Key == ConsoleKey.Enter) { break; }
      Console.Write('*');
      input += key.KeyChar;
    }
    
    Console.WriteLine("\n");
    return input;
  }
  
  public static int IdQuery( string nameQuery ) // Checks if a user id already exists, returns the line number
  {                                             // if it doesn't and returns a 0 if it does
    using StreamReader sr = new StreamReader(Paths.GetPath("PLYR"));
    {
      // SHA256 sha256 = SHA256.Create();
      // byte[] id = Encoding.UTF8.GetBytes(nameQuery);
      // byte[] idHash = sha256.ComputeHash(id);
      int currentLine = 0;
      
      while (sr.Peek() >= 0)
      {
        currentLine++;
        
        if ( sr.ReadLine() == nameQuery)
        {
          return currentLine;
        }
      }
    }
    
    return 0;
  }
  
  public static bool PasswordQuery( string inPwd, int lineOfName ) // Checks if password matches the one stored after the name
  {
    using StreamReader sr = new StreamReader(Paths.GetPath("PLYR"));
    {
      // SHA256 sha256 = SHA256.Create();
      // byte[] pwd = Encoding.UTF8.GetBytes(inPwd);
      // byte[] pwdHash = sha256.ComputeHash(pwd);
      
      for (int i = 0; i < lineOfName; i++)
      {
        sr.ReadLine();
      }
      
      if ( sr.ReadLine() == inPwd )
      {
        Console.WriteLine("Login successfull!");
        return true;
      }
    }
    
    Console.WriteLine("That password was incorrect. Please try again.");
    return false;
  }
  
  public static void ResetPlayersFile() // Deletes all data in players.txt
  {
    File.WriteAllText(Paths.GetPath("PLYR"), "******************************************************\n\nFormat:\n\nPlayerName\nPlayerPassword\nCurrentRoom\nPlayerSpawn\n\n******************************************************\n\n");
  }
  
  public static void Store( string inUserId, string inPassword ) // Stores a hashed user id along with a hashed password (SHA256)
  {
    if (!isValidPwd(inPassword))
    {
      Console.WriteLine("Not a valid password");
      return;
    }
    
    while (true)
    {
      string userId = inUserId;
      
      if (IdQuery(inUserId) == 0)
      {
        using (StreamWriter sw = File.AppendText(Paths.GetPath("PLYR")))
        {
          // SHA256 sha256 = SHA256.Create();
          // byte[] pwd = Encoding.UTF8.GetBytes(inPassword);
          // byte[] id = Encoding.UTF8.GetBytes(inUserId);
          // byte[] pwdHash = sha256.ComputeHash(pwd); // TODO: Add a salt that can be set by admin
          // byte[] idHash = sha256.ComputeHash(id); // TODO: Add a salt that can be set by admin
          
          sw.WriteLine(inUserId);
          sw.WriteLine(inPassword);
          sw.WriteLine("Spawn Room");
          sw.WriteLine("Spawn Room");
          
          break;
        }
      }
      
      Console.WriteLine($"The name: {inUserId} has already been taken");
      return;
    }
  }
  
  public static void LoginQuery() // Prompts for Name and then password
  {
    Console.WriteLine();
    Console.WriteLine("Please enter your character's name.");
    Console.Write("Name: ");
    string inName = Console.ReadLine();
    int lineOfName = IdQuery(inName);
    
    if (lineOfName == 0)
    {
      Console.WriteLine("Name does not exist, please try again.");
      LoginQuery();
      return;
    }
    
    Console.WriteLine($"Now please enter the password for {inName}");
    string inPwd = HideInput();
    
    if ( PasswordQuery(inPwd, lineOfName) )
    {
      Console.WriteLine($"Welcome back {inName}!");
      return;
    }
  }
}