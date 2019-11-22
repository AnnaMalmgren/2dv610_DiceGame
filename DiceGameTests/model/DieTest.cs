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
        int actual = sut.GetFaceValue();
        Assert.InRange<int>(actual, 1, 6);

      }

      [Fact]
      public void faceValueShouldReturnSpecificValue()
      {
        var mockRandom = new Mock<Random>();
        mockRandom.Setup(m => m.Next(1, 7)).Returns(6);
        
        Die sut = new Die(mockRandom.Object);
        sut.RollDie();
        int actual = sut.GetFaceValue();

        Assert.Equal(6, actual);
      }

      [Fact]
      public void faceValueShouldBeTheSameWhenDieNotRolled()
      {
        var mockRandom = new Mock<Random>();
        mockRandom.Setup(m => m.Next(1, 7)).Returns(5);
        Die sut = new Die(mockRandom.Object);
        sut.RollDie();

        int value1 = sut.GetFaceValue();
        int value2 = sut.GetFaceValue();

        Assert.Equal(value1, value2);
      }

      [Fact]
      public void addSubscribersShouldAddOneSubscriberToList()
      {
        var mockRandom = new Mock<Random>();
        Die sut = new Die(mockRandom.Object);
        Mock<IRollDieObserver> subscriber = new Mock<IRollDieObserver>();
        sut.AddSubscriber(subscriber.Object);

        Assert.Equal(1, sut.Subscribers.Count);
      }
  }
}


