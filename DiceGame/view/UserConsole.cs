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

      public string ReadKey()
      {
          return Console.ReadLine();
      }

  }
}