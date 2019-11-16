using System;
using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DieTest
  {
      [Fact]
      public void sidesDieDefaultShouldBeSix()
      {
        Die sut = new Die(new Random());
        int actual = sut.Sides;
        Assert.Equal(6, actual);
      }

      [Fact]
      public void sidesDieShouldBeTwelve()
      {
        Die sut = new Die(new Random(), 12);
        int actual = sut.Sides;
        Assert.Equal(12, actual);
      }

      [Fact]
      public void sidesOfDieExceptionIfLessThanFour()
      {
        Assert.Throws<ArgumentException>(() => new Die(new Random(), 0));
      }

      [Fact]
      public void sidesOfDieExceptionIfMoreThanTwelve()
      {
        Assert.Throws<ArgumentException>(() => new Die(new Random(), 13));
      }

      [Fact]
      public void sidesOfDieMustBeEvenValue()
      {
        Assert.Throws<ArgumentException>(() => new Die(new Random(), 5));
      }

      [Fact]
      public void faceValueShouldReturnValueInRange()
      {
        Die sut = new Die(new Random());
        sut.RollDie();
        int actual = sut.FaceValue;
        Assert.InRange<int>(actual, 1, 6);

      }

      [Fact]
      public void faceValueShouldReturnSpecificValue()
      {
        var mockRandom = new Mock<Random>();
        mockRandom.Setup(m => m.Next(1, 7)).Returns(6);
        
        Die sut = new Die(mockRandom.Object);
        sut.RollDie();
        int actual = sut.FaceValue;

        Assert.Equal(6, actual);
      }

      [Fact]
      public void faceValueShouldBeTheSameWhenDieNotRolled()
      {
        Die sut = new Die(new Random());
        sut.RollDie();

        int value = sut.FaceValue;
        int actual = sut.FaceValue;

        Assert.Equal(value, actual);
      }
  }
}


