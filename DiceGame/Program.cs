﻿using System;
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
            DiceView dView = new DiceView(console);
            DiceFactory factory = new DiceFactory();
            DiceCup dices = new DiceCup(factory);
            PlayGameHandler game = new PlayGameHandler(gView, dView, dices);
            game.StartGame();
            game.PlayGame();
        }
    }
}
