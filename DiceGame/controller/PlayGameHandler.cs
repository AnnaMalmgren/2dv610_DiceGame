using System;
using System.Collections.Generic;


namespace DiceGame.controller
{
  public class PlayGameHandler
  {
      private view.IMainGameView _view;

      private model.DiceCup _diceCupe;

      private int _guessedScore = 10;

      public PlayGameHandler(view.IMainGameView view, model.DiceCup cup)
      {
          this._view = view;
          this._diceCupe = cup;
      }

      public void PlayGame()
      {
  
      }

      public bool StartGame()
      {
          this._view.DisplayWelcomeMsg();

          return this._view.UserWantsToPlay();
      }

      public void PlayOneRound(int numOfDices)
      {
          this._diceCupe.SetDice(numOfDices);
          this._diceCupe.RollDice();
          this._diceCupe.GetScore();
      }


      public bool GetWinner(int score)
      {
          return this._guessedScore == score;
      }

  }
}