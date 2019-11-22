using System;
using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DieTest
  {
      private Die sut;

      private Mock<Random> randMock;

      public DieTest()
      {
        this.randMock = new Mock<Random>();
        this.sut = new Die(this.randMock.Object);

      }

      [Fact]
      public void sidesDieDefaultShouldBeSix()
      {
        int actual = this.sut.Sides;
        Assert.Equal(6, actual);
      }

      [Fact]
      public void sidesDieShouldBeTwelve()
      {
        Die sut = new Die(this.randMock.Object, 12);
        int actual = sut.Sides;
        Assert.Equal(12, actual);
      }

      [Fact]
      public void sidesOfDieExceptionIfLessThanFour()
      {
        Assert.Throws<ArgumentException>(() => new Die(this.randMock.Object, 0));
      }

      [Fact]
      public void sidesOfDieExceptionIfMoreThanTwelve()
      {
        Assert.Throws<ArgumentException>(() => new Die(this.randMock.Object, 13));
      }

      [Fact]
      public void sidesOfDieMustBeEvenValue()
      {
        Assert.Throws<ArgumentException>(() => new Die(this.randMock.Object, 5));
      }

      [Fact]
      public void getFaceValueShouldReturnValueInExpectedRange()
      {
        Die sut = new Die(new Random());
        sut.RollDie();
        int actual = sut.GetFaceValue();
        Assert.InRange<int>(actual, 1, 6);

      }

      [Fact]
      public void getFaceValueShouldReturnSpecificValueFromRandom()
      {
        this.randMock.Setup(m => m.Next(1, 7)).Returns(6);
        
        this.sut.RollDie();
        int actual = this.sut.GetFaceValue();

        Assert.Equal(6, actual);
      }

      [Fact]
      public void getFaceValueShouldBeTheSameWhenDieNotRolled()
      {
        this.randMock.Setup(m => m.Next(1, 7)).Returns(5);
        this.sut.RollDie();

        int value1 = this.sut.GetFaceValue();
        int value2 = this.sut.GetFaceValue();

        Assert.Equal(value1, value2);
      }

      [Fact]
      public void notifySubscribersShouldCallDieRolledOnSubscribers()
      {
         Mock<IRollDieObserver> subscriberMock = new Mock<IRollDieObserver>();
         this.sut.AddSubscriber(subscriberMock.Object);
         this.sut.AddSubscriber(subscriberMock.Object);

         this.sut.NotifySubscribers();
         
     
          subscriberMock.Verify(mock => mock.DieRolled(), Times.Exactly(2));
      }
  }
}


