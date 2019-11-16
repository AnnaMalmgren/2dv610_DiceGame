using System;
using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DiceCupTest
  {
      [Fact]
      public void shouldReturnDieWithChosenFaceValue()
      {
        DiceCup sut = new DiceCup();
        sut.SetDice();
        int actual = sut.Dice.Count;
        Assert.Equal(2, actual);
          
      }
  }
}
