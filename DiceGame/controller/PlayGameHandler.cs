using System;
using System.Collections.Generic;


namespace DiceGame.controller
{
  public class PlayGameHandler : model.IRollDieObserver
  {
      private view.IMainGameView _view;


      private model.DiceCup _diceCup;

      private int _guessedScore;

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

          this._view.PrintGameResult(this._diceCup.GetScore(), this.GetWinner());

          this._diceCup.Reset();
        }
      }

      public int PlayOneRound()
      {
        int dices = this._view.GetNrOfDices();
        this._guessedScore = this._view.GetScoreGuess();
        return this._diceCup.GetOneRoundScore(dices);
      }

      public void DieRolled(int faceValue)
      {
        this._view.PrintDie(faceValue);
      }

      public bool GetWinner()
      {
        int score = this._diceCup.GetScore();
        return this._guessedScore == score;
      }

  }
}