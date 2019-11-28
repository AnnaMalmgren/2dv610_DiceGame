using System;

namespace DiceGame.model
{
  public class DieFactory
  {
    public virtual IDie GetDie()
    {
      return new Die(new Random());
    }
  }
}