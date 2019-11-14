using System;
using System.Collections.Generic;


namespace DiceGame.model
{
  public class Die
  {
    private readonly List<int> _allowedNrOfSides = new List<int>() {4, 6, 8, 10, 12};

    private Random _random;

    private int _sides;

    public int Sides
    {
      get => _sides;
      private set
      {
        if (ValidateNrOfSides(value))
        {
          this._sides = value;
        }
      }
    }

    public Die(int sides, Random rand)
    {
      this.Sides = sides;
      this._random = rand;
    }

    public int GetValue()
    {
      int minValue = 1;
      int maxValue = this.Sides + 1;

      return this._random.Next(minValue, maxValue);
    }

    public int RollDie()
    {
      return 0;
    }

    private bool ValidateNrOfSides(int value)
    {
      if (!_allowedNrOfSides.Contains(value))
        {
          throw new ArgumentException();
        }

        return true;
    }

  }
}
