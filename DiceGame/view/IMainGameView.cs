
namespace DiceGame.view
{
  public interface IMainGameView
  {
      void DisplayWelcomeMsg();

      bool UserWantsToPlay();

      char GetUserInput();

      int GetNrOfDices();

      void PrintGameResult(bool isWinner);

  }
}
