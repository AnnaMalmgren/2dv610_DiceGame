using System.Diagnostics.CodeAnalysis;

namespace DiceGame
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            model.GameHandlerFactory gameFactory = new model.GameHandlerFactory();
            App app = new App(gameFactory);

            app.Run();
        }
    }
}
