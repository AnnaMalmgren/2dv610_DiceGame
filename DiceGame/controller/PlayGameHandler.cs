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

      public void PlayGame()
      {
          this._view.DisplayWelcomeMsg();

          this._view.GetNrOfDices();
      }
    

  }
}