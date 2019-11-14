using System;
using System.Collections.Generic;


namespace DiceGame.model
{
  public class Die
  {
    private readonly List<int> _allowedNrOfSides = new List<int>() {4, 6, 8, 10, 12};

    private int _sides;
    public int Sides
    {
      get => _sides;
      private set
      {
        if (validateNrOfSides(value))
        {
          this._sides = value;
        }
      }
    }

    public Die(int sides)
    {
      this.Sides = sides;
    }

    private bool validateNrOfSides(int value)
    {
      if (!_allowedNrOfSides.Contains(value))
        {
          throw new ArgumentException();
        }

        return true;
    }

  }
}
