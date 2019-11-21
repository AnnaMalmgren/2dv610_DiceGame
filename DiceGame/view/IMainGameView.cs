
namespace DiceGame.view
{
  public interface IMainGameView
  {
      void DisplayWelcomeMsg();

      bool UserWantsToPlay();

      char GetUserInput();

      void PrintGameResult(bool isWinner);

  }
}
