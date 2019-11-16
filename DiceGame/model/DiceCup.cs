using System;
using System.Collections.Generic;


namespace DiceGame.model
{
  public class DiceCup
  {

    private List<Die> _dice;

    private DiceFactory _factory = new DiceFactory();

    public IReadOnlyList<Die> Dice => this._dice.AsReadOnly();
    
    public DiceCup()
    {
      this._dice = new List<Die>();
    }

    public void SetDice(int nrOfDice, int nrOfSides = 6)
    {
      for (int i = 0; i < nrOfDice; i++)
      {
        this._dice.Add(this._factory.getDie(nrOfSides));
      }
    }

    public void RollDice()
    {
      return;
    }
   
  }
}
