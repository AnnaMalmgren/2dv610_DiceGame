using System;
using System.Collections.Generic;


namespace DiceGame.model
{
  public class Die : IDie
  {
    private readonly List<int> _allowedNrOfSides = new List<int>() {4, 6, 8, 10, 12};

    private List<IRollDieObserver> _subscribers;

    public IReadOnlyList<IRollDieObserver> Subscribers => this._subscribers;

    private Random _random;

    private int _faceValue;

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

    public Die(Random rand, int sides = 6)
    {
      this.Sides = sides;
      this._random = rand;
      this._subscribers = new List<IRollDieObserver>();
    }

    public void RollDie()
    {
      int minValue = 1;
      int maxValue = this.Sides + 1;

      this._faceValue = this._random.Next(minValue, maxValue);
    }

    public int GetFaceValue()
    {
      return this._faceValue;
    }

    public bool ValidateNrOfSides(int value)
    {
      if (!_allowedNrOfSides.Contains(value))
        {
          throw new ArgumentException();
        }

        return true;
    }

  }
}
