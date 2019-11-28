using DiceGame.model;
using DiceGame.controller;
using DiceGame.view;
using System.Diagnostics.CodeAnalysis;

namespace DiceGame
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            IUserConsole console = new UserConsole();
            GameView gView = new GameView(console);
            DiceCupFactory dices = new DiceCupFactory();
            PlayGameHandler game = new PlayGameHandler(gView, dices);
            App app = new App(game);

            app.Run();
        }
    }
}
