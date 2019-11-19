using System;
using System.Collections.Generic;

namespace DiceGame.view
{
  public class GameView
  {
    private IUserConsole _console;

    private const char _exitKey = 'q';

    public GameView(IUserConsole console)
    {
      this._console = console;
    }

    public void DisplayWelcomeMsg()
    {
      this._console.WriteLine($"Welcome to DiceGame. Press any Key to play, or { _exitKey } to Quit");
    }

    public char GetUserInput()
    {
      return ' ';
    }

  }
}
