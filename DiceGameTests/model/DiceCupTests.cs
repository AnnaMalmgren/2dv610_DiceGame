using System;
using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DiceCupTest
  {
      private Mock<DiceFactory> factoryMock;
      private Mock<IDie> dieMock;

      private Mock<IRollDieObserver> subscriberMock;

      private DiceCup sut;

      public DiceCupTest()
      {
        this.factoryMock = new Mock<DiceFactory>();
        this.dieMock = new Mock<IDie>();
        this.subscriberMock = new Mock<IRollDieObserver>();
        this.sut = new DiceCup(this.factoryMock.Object);

        this.factoryMock.Setup(mock => mock.GetDie()).Returns(this.dieMock.Object);
        this.dieMock.Setup(mock => mock.RollDie());
        this.dieMock.Setup(mock => mock.GetFaceValue()).Returns(5);
      }

      [Fact]
      public void factoryGetDieShouldNotBeCalledWhenSetDiceIsCalledWith0()
      {
        this.sut.SetDice(0);
        this.factoryMock.Verify(mock => mock.GetDie(), Times.Exactly(0));

      }

      [Fact]
      public void factoryGetDieShoulbBeCalledForAllDice()
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
        this.sut.RollDice();
        int actual = this.sut.GetScore();

        Assert.Equal(5, actual);
      }

      [Fact]
      public void getScoreShouldReturnSumOfFaceValuesOfAllDice()
      {
        this.sut.SetDice(5);
        this.sut.RollDice();
        int actual = this.sut.GetScore();

        Assert.Equal(25, actual);
      }

      [Fact]
      public void setDiceShouldAddChosenNumOfDiceToDiceList()
      {
        this.sut.SetDice(5);
        int actual = this.sut.Dice.Count;
        
        Assert.Equal(5, actual);
      }

      [Fact]
      public void getOneRoundScoreShouldReturnScore()
      {
        int actual = this.sut.GetOneRoundScore(5);
        
        Assert.Equal(25, actual);
      }

      [Fact]
      public void resetShouldEmptyDiceList()
      {
        this.sut.SetDice(5);
        this.sut.Reset();

        int actual = this.sut.Dice.Count;

        Assert.Equal(0, actual);
      }

       [Fact]
      public void addSubscribersShouldAddOneSubscriberToList()
      {
        this.sut.AddSubscriber(this.subscriberMock.Object);

        Assert.Equal(1, this.sut.Subscribers.Count);
      }

      [Fact]
      public void notifySubscribersShouldCallDieRolledOnSubscribers()
      {
         this.sut.AddSubscriber(this.subscriberMock.Object);
         this.sut.AddSubscriber(this.subscriberMock.Object);
         int input = 5;
         this.sut.NotifySubscribers(input);
         
         subscriberMock.Verify(mock => mock.DieRolled(It.IsAny<int>()), Times.Exactly(2));
      }


  }
}
