using System;
using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DiceCupTest
  {
      private Mock<DieFactory> factoryMock;
      private Mock<IDie> dieMock;

      private Mock<IRollDieObserver> subscriberMock;

      private DiceCup sut;

      private int faceValue = 5;

      public DiceCupTest()
      {
        this.factoryMock = new Mock<DieFactory>();
        this.dieMock = new Mock<IDie>();
        this.subscriberMock = new Mock<IRollDieObserver>();
        this.sut = new DiceCup(this.factoryMock.Object);

        this.factoryMock.Setup(mock => mock.GetDie()).Returns(this.dieMock.Object);
        this.dieMock.Setup(mock => mock.GetFaceValue()).Returns(this.faceValue);
      }

      [Fact]
      public void factoryGetDieShouldNotBeCalledWhenSetDiceIsCalledWith0()
      {
        this.sut.SetDice(0);
        this.factoryMock.Verify(mock => mock.GetDie(), Times.Exactly(0));
      }

      [Fact]
      public void factoryGetDieShoulbBeCalledForAllDiceSetBySetDice()
      {
        this.sut.SetDice(5);
        this.factoryMock.Verify(mock => mock.GetDie(), Times.Exactly(5));
      }
      
      [Fact]
      public void rolledDieShouldNotBeCalledWhenSetDiceIsCalledWith0()
      {
        this.sut.SetDice(0);
        this.sut.RollDice();
        this.dieMock.Verify(mock => mock.RollDie(), Times.Exactly(0));
      }

      [Fact]
      public void rollDieShoulbBeCalledForAllDice()
      {
        this.sut.SetDice(5);
        this.sut.RollDice();
        this.dieMock.Verify(mock => mock.RollDie(), Times.Exactly(5));
      }
      
      [Fact]
      public void rollDieShouldNotifySubscribers()
      {
         Mock<IRollDieObserver> subscriberMock = new Mock<IRollDieObserver>();
         this.sut.AddSubscriber(subscriberMock.Object);
         this.sut.SetDice(3);
         this.sut.RollDice();

         subscriberMock.Verify(mock => mock.DieRolled(It.IsAny<int>()), Times.Exactly(3));
      }
      
      [Fact]
      public void getScoreShouldReturnFaceValueOfDieWhenOnlyOneDie()
      {
        this.sut.SetDice(1);
        int actual = this.sut.GetScore();

        Assert.Equal(this.faceValue, actual);
      }

      [Fact]
      public void getScoreShouldReturnSumOfFaceValuesOfAllDice()
      {
        this.sut.SetDice(5);
        int actual = this.sut.GetScore();
        int expected = this.faceValue * 5;

        Assert.Equal(expected, actual);
      }

      [Fact]
      public void getOneRoundScoreShouldReturnScore()
      {
        int numDices = 5;
        int actual = this.sut.GetOneRoundScore(numDices);
        int expected = this.faceValue * numDices;
        
        Assert.Equal(expected, actual);
      }

      [Fact]
      public void resetShouldEmptyDiceListAndRollDiceShouldNotBeCalled()
      {
        this.sut.SetDice(5);
        this.sut.Reset();
        this.sut.RollDice();

        this.dieMock.Verify(mock => mock.RollDie(), Times.Exactly(0));
      }

      [Fact]
      public void notifySubscribersShouldNotCallDieRolledIfZeroSubscribers()
      {
         this.sut.NotifySubscribers(this.faceValue);
        
         subscriberMock.Verify(mock => mock.DieRolled(It.IsAny<int>()), Times.Exactly(0));
      }

      [Fact]
      public void notifySubscribersShouldCallDieRolledOnSubscribers()
      {
         this.sut.AddSubscriber(this.subscriberMock.Object);
         this.sut.AddSubscriber(this.subscriberMock.Object);
         this.sut.AddSubscriber(this.subscriberMock.Object);
         this.sut.NotifySubscribers(this.faceValue);
         
         subscriberMock.Verify(mock => mock.DieRolled(It.IsAny<int>()), Times.Exactly(3));
      }
  }
}
