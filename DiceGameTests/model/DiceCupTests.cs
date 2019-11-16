using System;
using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DiceCupTest
  {
      [Fact]
      public void setDiceShouldReturnChosenNrOfDice()
      {
        DiceCup sut = new DiceCup();
        sut.SetDice(2);
        int actual = sut.Dice.Count;
        Assert.Equal(2, actual);
          
      }
  }
}
