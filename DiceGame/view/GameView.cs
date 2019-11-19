using System;
using System.Collections.Generic;

namespace DiceGame.view
{
  public class GameView
  {
    private IUserConsole _console;
    public GameView(IUserConsole console)
    {
      this._console = console;
    }

    public void DisplayMainMenu()
    {
      this._console.WriteLine("Main Menu");
    }

  }
}
