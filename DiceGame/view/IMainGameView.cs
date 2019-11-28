
namespace DiceGame.view
{
  public interface IMainGameView
  {
      void DisplayWelcomeMsg();
      bool UserWantsToPlay();
      char GetUserInputChar();
      int GetNrOfDices();
      void PrintDie(int dieFaceValue);
      void PrintGameResult(int score, bool isWinner);
      int GetScoreGuess();
  }
}
