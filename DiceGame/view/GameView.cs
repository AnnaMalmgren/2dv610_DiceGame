using System;


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

    
    public  virtual void PrintDie(int faceValue)
    {
      this._console.WriteLine($"Facevalue: {faceValue}");
    }

    public void PrintGameResult(bool isWinner)
    {
      string msg = isWinner ? _winMsg : _lostMsg;
      this._console.WriteLine(msg);
    }

    public void PrintTotalScore(int score)
    {
    }

    public int GetNrOfDices()
    {
      this._console.WriteLine(">Enter number of dices you want in the game: ");

      return this.GetInputAndParseToInt();
    }

    public int GetScoreGuess()
    {
      this._console.WriteLine(">Enter the score you think will be rolled: ");
      return this.GetInputAndParseToInt();
    }

    private int GetInputAndParseToInt()
    {
      do
      {
        if (int.TryParse(this._console.ReadLine(), out int numOfDices))
        {
          return numOfDices;
        }

      } while(true);

    }

  }
}