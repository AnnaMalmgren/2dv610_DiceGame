using System;

namespace DiceGame.model
{
    public class DiceCupFactory
    {
        public virtual IDiceCup GetDiceCup()
        {
            return new DiceCup(new DiceFactory());
        }

    }
}