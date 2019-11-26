using System;
using System.Collections.Generic;


namespace DiceGame.controller
{
  public class PlayGameHandler : model.IRollDieObserver
  {
      private view.IMainGameView _view;


      private model.DiceCup _diceCup;

      private int _guessedScore;

      private int _totalScore;

      public PlayGameHandler(view.IMainGameView view, model.DiceCup cup)
      {
          this._view = view;
          this._diceCup = cup;
          this._diceCup.AddSubscriber(this);
      }

      public bool StartGame()
      {
        this._view.DisplayWelcomeMsg();
        return this._view.UserWantsToPlay();
      }

      public void PlayGame()
      {  
        while(this.StartGame())
        {
          this.PlayOneRound();

          this._view.PrintGameResult(this._totalScore, this.GetWinner());

          this._diceCup.Reset();
        }
      }

      public void PlayOneRound()
      {
        int dices = this._view.GetNrOfDices();
        this._guessedScore = this._view.GetScoreGuess();
        this._totalScore = this._diceCup.GetOneRoundScore(dices);
      }

      public void DieRolled(int faceValue)
      {
        this._view.PrintDie(faceValue);
      }

      public bool GetWinner()
      {
        this._view.PrintGameResult(10, true);
        return this._guessedScore == this._totalScore;
      }

  }
}