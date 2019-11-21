using System;
using System.Collections.Generic;


namespace DiceGame.controller
{
  public class PlayGameHandler
  {
      private view.IMainGameView _view;
      public PlayGameHandler(view.IMainGameView view)
      {
          this._view = view;
      }

      public void StartGame()
      {
          this._view.DisplayWelcomeMsg();
          
          int dices = this._view.GetNrOfDices();
      }

      public void PlayGame(int numOfDices, model.DiceCup cup)
      {
          cup.SetDice(numOfDices);
      }
  }
}