using System.Collections.Generic;

namespace DiceGame.model
{
  public class DiceCup : IDiceCup
  {
    private List<IDie> _dice;

    private DieFactory _factory;

    private List<IRollDieObserver> _subscribers;

    
    public DiceCup(DieFactory factory)
    {
      this._dice = new List<IDie>();
      this._subscribers = new List<IRollDieObserver>();
      this._factory = factory;
    }

    public int GetOneRoundScore(int numDice)
    {
      this.SetDice(numDice);
      this.RollDice();
      return this.GetScore();
    }

    public void SetDice(int numDice)
    {
      for (int i = 0; i < numDice; i++)
      {
        this._dice.Add(this._factory.GetDie());
      }
    }

    public void RollDice()
    {
      foreach (IDie die in this._dice)
      {
        die.RollDie();
        this.NotifySubscribers(die.GetFaceValue());
      }
    }

    public int GetScore()
    {
      int score = 0;

      foreach (IDie die in this._dice)
      {
        score += die.GetFaceValue();
      }

      return score;
    }

    public void Reset()
    {
      this._dice.Clear();
    }

    public void AddSubscriber(IRollDieObserver subscriber)
    {
      this._subscribers.Add(subscriber);
    }

    public void NotifySubscribers(int faceValue)
    {
      this._subscribers.ForEach(subscriber => subscriber.DieRolled(faceValue));
    }

  }
}
