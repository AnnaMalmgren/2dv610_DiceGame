using System;

namespace DiceGame
{
    public class App
    {
        private controller.PlayGameHandler _game;
        public App(controller.PlayGameHandler game)
        {
            this._game = game;
        }

        public void Run()
        {
            this._game.StartGame();
        }

    }
}