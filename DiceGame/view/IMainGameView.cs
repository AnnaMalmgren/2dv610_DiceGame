
namespace DiceGame.view
{
  public interface IMainGameView
  {
      void DisplayWelcomeMsg();

      bool UserWantsToPlay();

      char GetUserInput();

      int GetNrOfDices();

      int GetScoreGuess();

      void PrintGameResult(bool isWinner);

  }
}
