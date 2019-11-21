using System;
using System.Collections.Generic;

namespace DiceGame.view
{
    public class DiceView
    {
        IUserConsole _console;

        public DiceView(IUserConsole console)
        {
            this._console = console;
        }

        public void PrintDiceResult(List<model.IDie> diceCup, int score)
        {
            foreach (model.IDie die in diceCup)
            {
                this.PrintDie(die);
            }
            
            this._console.WriteLine($"Total Score: {score}");
        }

        public void PrintDie(model.IDie die)
        {
            this._console.WriteLine($"Facevalue: {die.GetFaceValue()}");
        }
    }
}