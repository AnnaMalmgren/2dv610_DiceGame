using System;

namespace DiceGame.model
{
    class DiceFactory
    {
        public Die getDie(int nrSides = 6)
        {
            return new Die(new Random(), nrSides);
        }

    }
}