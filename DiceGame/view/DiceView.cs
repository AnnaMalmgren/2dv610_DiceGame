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

        public virtual void PrintDiceResult(IReadOnlyList<model.IDie> diceCup)
        {
            foreach (model.IDie die in diceCup)
            {
                this.PrintDie(die);
            }
            
        }

        public void PrintDie(model.IDie die)
        {
            this._console.WriteLine($"Facevalue: {die.GetFaceValue()}");
        }
    }
}