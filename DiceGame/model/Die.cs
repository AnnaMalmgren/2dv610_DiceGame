using System;


namespace DiceGame.model
{
  public class Die
  {
    private int _sides;
    public int Sides
    {
      get => _sides;
    }

    public Die(int sides)
    {
      this._sides = sides;
    }
  }
}
