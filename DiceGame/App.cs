
namespace DiceGame
{
    public class App
    {
        private controller.PlayGameHandler _game;
        public App(model.GameHandlerFactory gameFactory)
        {
           this._game = gameFactory.GetPlayGameHandler();
        }

        public void Run()
        {
            while(this._game.StartGame())
            {
                this._game.PlayGame();
            }
        }

    }
}