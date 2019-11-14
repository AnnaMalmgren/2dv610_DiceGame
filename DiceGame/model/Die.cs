using System;


namespace DiceGame.model
{
  public class Die
  {
    private int _sides;
    public int Sides
    {
      get => _sides;
      set
      {
        if (value == 0)
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
