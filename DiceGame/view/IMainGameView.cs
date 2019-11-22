
namespace DiceGame.view
{
  public interface IMainGameView
  {
      void DisplayWelcomeMsg();

      bool UserWantsToPlay();

      char GetUserInput();

      int GetNrOfDices();

      void PrintDie(int dieFaceValue);

      void PrintTotalScore(int score);

      int GetScoreGuess();

      void PrintGameResult(bool isWinner);

  }
}
