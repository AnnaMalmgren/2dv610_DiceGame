using DiceGame.model;
using System.Diagnostics.CodeAnalysis;

namespace DiceGame
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            GameHandlerFactory gameFactory = new GameHandlerFactory();
            App app = new App(gameFactory);

            app.Run();
        }
    }
}
