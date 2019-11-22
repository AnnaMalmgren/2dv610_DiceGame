using System.Collections.Generic;

namespace DiceGame.model
{
  public class DiceCup
  {

    private List<IDie> _dice;

    private DiceFactory _factory;

    private List<IRollDieObserver> _subscribers;

    public IReadOnlyList<IRollDieObserver> Subscribers => this._subscribers.AsReadOnly();

    public IReadOnlyList<IDie> Dice => _dice.AsReadOnly();

    
    public DiceCup(DiceFactory factory)
    {
      this._dice = new List<IDie>();
      this._subscribers = new List<IRollDieObserver>();
      this._factory = factory;
    }

    public virtual void SetDice(int nrOfDice)
    {
      for (int i = 0; i < nrOfDice; i++)
      {
        this._dice.Add(this._factory.GetDie());
      }
    }

    public virtual void RollDice()
    {
      foreach (IDie die in this._dice)
      {
        die.RollDie();
        this._subscribers.ForEach(sub => sub.DieRolled());
      }
    }

    public virtual int GetScore()
    {
      int score = 0;

      foreach (IDie die in this._dice)
      {
        score += die.GetFaceValue();
      }

      return score;
    }

    public virtual void AddSubscriber(IRollDieObserver subscriber)
    {
      this._subscribers.Add(subscriber);
    }

    public void NotifySubscribers()
    {
      this._subscribers.ForEach(subscriber => subscriber.DieRolled());
    }

  }
}
