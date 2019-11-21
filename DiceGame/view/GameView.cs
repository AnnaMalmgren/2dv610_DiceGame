using System;
using System.Collections.Generic;

namespace DiceGame.view
{
  public class GameView : IMainGameView
  {
    private IUserConsole _console;

    private const char _exitKey = 'q';

    private const string _winMsg = "Congratualtions you win!";
    private const string _lostMsg = "Sorry you lost!";

    

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
      return Char.ToLower(this._console.ReadKey());
    }

    public void PrintGameResult(bool isWinner)
    {
      string msg = isWinner ? _winMsg : _lostMsg;
      this._console.WriteLine(msg);
    }

    public int GetNrOfDices()
    {
      do
      {
        this._console.WriteLine(">Enter number of dices you want in the game: ");

        if (int.TryParse(this._console.ReadLine(), out int numOfDices))
        {
          return numOfDices;
        }

      } while(true);
    }

    
  }
}