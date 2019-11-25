using System;
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
            DiceFactory factory = new DiceFactory();
            DiceCup dices = new DiceCup(factory);
            PlayGameHandler game = new PlayGameHandler(gView, dices);

            game.PlayGame();
        }
    }
}
