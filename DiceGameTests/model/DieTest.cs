using System;
using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DieTest
  {
      [Fact]
      public void sidesDieShouldBeSix()
      {
        Die sut = new Die(6, new Random());
        int actual = sut.Sides;
        Assert.Equal(6, actual);
      }

      [Fact]
      public void sidesOfDieExceptionIfLessThanFour()
      {
        Assert.Throws<ArgumentException>(() => new Die(0, new Random()));
      }

      [Fact]
      public void sidesOfDieExceptionIfMoreThanTwelve()
      {
        Assert.Throws<ArgumentException>(() => new Die(13, new Random()));
      }

      [Fact]
      public void sidesOfDieMustBeEvenValue()
      {
        Assert.Throws<ArgumentException>(() => new Die(5, new Random()));
      }

      [Fact]
      public void getValueShouldReturnValueInRange()
      {
        Die sut = new Die(8, new Random());
        int actual = sut.GetValue();
        Assert.InRange<int>(actual, 1, 8);

      }

      [Fact]
      public void getValueShouldReturnSpecificValue()
      {
        var mockRandom = new Mock<Random>();
        mockRandom.Setup(m => m.Next(1, 7)).Returns(6);
        
        Die sut = new Die(6, mockRandom.Object);
        int actual = sut.GetValue();

        Assert.Equal(6, actual);
      }

      [Fact]
      public void getValueShouldBeTheSameWhenDieNotRolled()
      {
        Die sut = new Die(6, new Random());
        sut.RollDie();
        int value = sut.GetValue();
        int actual = sut.GetValue();
        Assert.Equal(value, actual);
      }

  }
}


