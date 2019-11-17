using System;

namespace DiceGame.model
{
    public class DiceFactory
    {
        public virtual IDie GetDie()
        {
            return new Die(new Random());
        }

    }
}