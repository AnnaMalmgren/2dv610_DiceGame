using System;
using System.Collections.Generic;


namespace DiceGame.controller
{
  public class PlayGameHandler
  {
      private view.IMainGameView _view;

      private model.DiceCup _diceCupe;

      private int _guessedScore;

      public PlayGameHandler(view.IMainGameView view, model.DiceCup cup)
      {
          this._view = view;
          this._diceCupe = cup;
      }

      public void StartGame()
      {
          this._view.DisplayWelcomeMsg();
          
          int dices = this._view.GetNrOfDices();
      }

      public void PlayGame(int numOfDices)
      {
          this._diceCupe.SetDice(numOfDices);
          this._diceCupe.RollDice();
          this._guessedScore = this._diceCupe.GetScore();
      }


      public bool GetWinner(int score)
      {
          return true;
      }

  }
}