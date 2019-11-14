using System;
using Xunit;
using DiceGame.model;

namespace DiceGameTests
{
  public class DieTest
  {
      [Fact]
      public void nrOfSidesDie()
      {
        Die sut = new Die(6);
        int actual = sut.Sides;
        Assert.Equal(6, actual);
      }

      [Fact]
      public void sidesOfDieExceptionIfLessThanFour()
      {
        Assert.Throws<ArgumentException>(() => new Die(0));
      }

      [Fact]
      public void sidesOfDieExceptionIfMoreThanTwelve()
      {
        Assert.Throws<ArgumentException>(() => new Die(12));
      }
  }
}


