using System;
using System.Collections.Generic;


namespace DiceGame.model
{
  public class DiceCup
  {

    private List<Die> _dice;

    public IReadOnlyList<Die> Dice => this._dice.AsReadOnly();
    
    public DiceCup()
    {
      this._dice = new List<Die>();
    }

    public void SetDice(int nrOfDice, int nrOfSides = 6)
    {
      for (int i = 0; i < nrOfDice; i++)
      {
        this._dice.Add(this.createDie(nrOfSides));
      }
    }

    private Die createDie(int nrOfSides)
    {
      return new Die(new Random(), nrOfSides);
    }
   
  }
}
