namespace DiceGame.controller
{
  public class PlayGameHandler : model.IRollDieObserver
  {
    private view.IMainGameView _view;

    private model.DiceCupFactory _diceFactory;

    private int _guessedScore;

    private int _totalScore;

    public PlayGameHandler(view.IMainGameView view, model.DiceCupFactory diceFactory)
    {
      this._view = view;
      this._diceFactory = diceFactory;
    }

    public virtual bool StartGame()
    {
      this._view.DisplayWelcomeMsg();
      return this._view.UserWantsToPlay();
    }

    public virtual void PlayGame()
    {
      model.IDiceCup diceCup = this._diceFactory.GetDiceCup();
      this.PlayOneRound(diceCup);
      this.DisplayGameResult();
    }

    public void PlayOneRound(model.IDiceCup diceCup)
    {
      diceCup.AddSubscriber(this);
      this.SetGuessedAndTotalScore(diceCup);
      diceCup.Reset();
    }

    private void SetGuessedAndTotalScore(model.IDiceCup diceCup)
    {
      int dices = this._view.GetNrOfDice();
      this._guessedScore = this._view.GetScoreGuess();
      this._totalScore = diceCup.GetOneRoundScore(dices);
    }
    
    public void DisplayGameResult()
    {
      bool isWinner = this._guessedScore == this._totalScore;
      this._view.PrintGameResult(this._totalScore, isWinner);
    }
    
    public void DieRolled(int faceValue)
    {
      this._view.PrintDie(faceValue);
    }

  }
}