using System;
using System.Collections.Generic;


namespace DiceGame.view
{
  public class UserConsole : IUserConsole
  {
      public void WriteLine(string Message)
      {
          return;
      }

      public char ReadKey()
      {
          return Console.ReadKey().KeyChar;
      }

  }
}