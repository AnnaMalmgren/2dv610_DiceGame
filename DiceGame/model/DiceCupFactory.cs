using System;

namespace DiceGame.model
{
    public class DiceCupFactory
    {
        public virtual IDiceCup GetDiceCup()
        {
            throw new NotFiniteNumberException();
        }

    }
}