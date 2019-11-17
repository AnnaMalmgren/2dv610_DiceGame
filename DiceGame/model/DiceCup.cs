using System;
using System.Collections.Generic;


namespace DiceGame.model
{
  public class DiceCup
  {

    private List<IDie> _dice;

    private DiceFactory _factory;

    public IReadOnlyList<IDie> Dice => this._dice.AsReadOnly();
    
    public DiceCup(DiceFactory factory)
    {
      this._dice = new List<IDie>();
      this._factory = factory;
    }

    public void SetDice(int nrOfDice)
    {
      for (int i = 0; i < nrOfDice; i++)
      {
        this._dice.Add(this._factory.getDie());
      }
    }

    public void RollDice()
    {
      this._dice.ForEach(die => die.RollDie());
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

  }
}
