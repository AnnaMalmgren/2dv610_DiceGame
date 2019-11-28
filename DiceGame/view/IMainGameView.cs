
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
      void PrintGameResult(int score, bool isWinner);
      int GetScoreGuess();
      string GetGameResultMsg(bool isWinner);
  }
}
