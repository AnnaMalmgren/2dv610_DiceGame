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

    public bool UserWantsToPlay()
    {
      return this.GetUserInput() != _exitKey;
    }

    public char GetUserInput()
    {
      return this._console.ReadKey();
    }

    public void PrintDiceResult(List<model.IDie> diceCup, int score)
    {
      foreach (model.IDie die in diceCup)
      {
        this.PrintDie(die);
      }

      this._console.WriteLine($"Total Score: {score}");
    }

    public void PrintDie(model.IDie die)
    {
      this._console.WriteLine($"Facevalue: {die.GetFaceValue()}");
    }

    public int GetNrOfDices()
    {
      string input = this._console.ReadLine();
      return this.ConvertToInt(input);
    }

    private int ConvertToInt(string input)
    {
      if (int.TryParse(input, out int num))
      {
        return num;
      }
      else
      {
        throw new ArgumentException();
      }
    }

  }
}
