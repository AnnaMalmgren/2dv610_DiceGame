using System;

namespace DiceGame.model
{
    public class DiceFactory
    {
        public virtual IDie getDie()
        {
            return new Die(new Random());
        }

    }
}