using System;


namespace DiceGame.model
{
  public class Die
  {
    private const int minNrOfSides = 4;
    private const int maxNrOfSides = 12;
    private int _sides;
    public int Sides
    {
      get => _sides;
      private set
      {
        if (value < minNrOfSides || value > maxNrOfSides)
        {
          throw new ArgumentException();
        }

        this._sides = value;
      }
    }

    public Die(int sides)
    {
      this.Sides = sides;
    }

  }
}
