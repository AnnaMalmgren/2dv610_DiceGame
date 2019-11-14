using System;
using System.Collections.Generic;


namespace DiceGame.model
{
  public class Die
  {
    private readonly List<int> _allowedNrOfSides = new List<int>() {4, 6, 8, 10, 12};

    private Random _random;

    private int _faceValue;

    private int _sides;

    public int FaceValue
    {
      get => this._faceValue;
    }

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

    public void RollDie()
    {
      int minValue = 1;
      int maxValue = this.Sides + 1;

      this._faceValue = this._random.Next(minValue, maxValue);
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
