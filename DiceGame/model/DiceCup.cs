using System;
using System.Collections.Generic;


namespace DiceGame.model
{
  public class DiceCup
  {
    public List<Die> Dice; 
    
    public DiceCup()
    {
      this.Dice = new List<Die>();
    }

    public void SetDice()
    {
      this.Dice.Add(new Die(new Random()));
      this.Dice.Add(new Die(new Random()));
    }
   
  }
}
