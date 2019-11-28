using System;
using System.Collections.Generic;


namespace DiceGame.view
{
  public class UserConsole : IUserConsole
  {
    public void WriteLine(string message)
    {
      Console.WriteLine(message);
    }

    public char ReadKey()
    {
      int input = Console.Read();
      return Convert.ToChar(input);
    }

    public string ReadLine()
    {
      return Console.ReadLine();
    }
  }
}