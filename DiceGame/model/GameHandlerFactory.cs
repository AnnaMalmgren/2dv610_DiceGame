namespace DiceGame.model
{
  public class GameHandlerFactory
  {
    public virtual controller.PlayGameHandler GetPlayGameHandler()
    {
      view.IMainGameView view = new view.GameView(new view.UserConsole());
      DiceCupFactory dices = new DiceCupFactory();

      return new controller.PlayGameHandler(view, dices);
    }
  }
}