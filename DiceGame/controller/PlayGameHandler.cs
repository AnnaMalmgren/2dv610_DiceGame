using System;
using System.Collections.Generic;


namespace DiceGame.controller
{
  public class PlayGameHandler : model.IRollDieObserver
  {
      private view.IMainGameView _view;

      private view.DiceView _diceView;

      private model.DiceCup _diceCupe;

      private int _guessedScore;

      public PlayGameHandler(view.IMainGameView view, view.DiceView diceView, model.DiceCup cup)
      {
          this._view = view;
          this._diceCupe = cup;
          this._diceView = diceView;
      }

      public void PlayGame()
      {
        int dices = this._view.GetNrOfDices();
        this._guessedScore = this._view.GetScoreGuess();

        this.PlayOneRound(dices);

        this._view.PrintGameResult(this.GetWinner());
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
      }

      public void DieRolled()
      {
          this._diceView.PrintDiceResult(_diceCupe.Dice);
      }

      public bool GetWinner()
      {
          int score = this._diceCupe.GetScore();
          return this._guessedScore == score;
      }

  }
}