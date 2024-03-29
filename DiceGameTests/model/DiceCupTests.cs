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
      
      private int inputNumDices = 4;

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
      public void FactoryGetDieShouldNotBeCalledWhenSetDiceIsCalledWith0()
      {
        this.sut.SetDice(0);

        this.factoryMock.Verify(mock => mock.GetDie(), Times.Exactly(0));
      }

      [Fact]
      public void FactoryGetDieShoulbBeCalledForAllDiceSetBySetDice()
      {
        this.sut.SetDice(this.inputNumDices);

        this.factoryMock.Verify(mock => mock.GetDie(), Times.Exactly(this.inputNumDices));
      }
      
      [Fact]
      public void RollDieShouldNotBeCalledWhenSetDiceIsCalledWith0()
      {
        this.sut.GetOneRoundScore(0);

        this.dieMock.Verify(mock => mock.RollDie(), Times.Exactly(0));
      }

      [Fact]
      public void RollDieShoulbBeCalledForAllDiceSetBySetDice()
      {
        this.sut.GetOneRoundScore(this.inputNumDices);

        this.dieMock.Verify(mock => mock.RollDie(), Times.Exactly(this.inputNumDices));
      }
      
      [Fact]
      public void RollDieShouldNotifySubscribersForEveryRollDie()
      {
         this.sut.AddSubscriber(this.subscriberMock.Object);
         this.sut.GetOneRoundScore(this.inputNumDices);

         subscriberMock.Verify(mock => mock.DieRolled(It.IsAny<int>()), Times.Exactly(this.inputNumDices));
      }

      [Fact]
      public void GetOneRoundScoreShouldReturnFaceValueOfDieWhenOnlyOneDie()
      {
        int actual = this.sut.GetOneRoundScore(1);

        Assert.Equal(this.faceValue, actual);
      }

      [Fact]
      public void GetOneRoundScoreShouldReturnTotalScore()
      {
        int actual = this.sut.GetOneRoundScore(this.inputNumDices);
        int expected = this.faceValue * this.inputNumDices;
        
        Assert.Equal(expected, actual);
      }

      [Fact]
      public void ResetShouldEmptyDiceListAndRollDiceShouldNotBeCalled()
      {
        this.sut.SetDice(this.inputNumDices);
        this.sut.Reset();
        this.sut.RollDice();

        this.dieMock.Verify(mock => mock.RollDie(), Times.Exactly(0));
      }

      [Fact]
      public void NotifySubscribersShouldNotCallDieRolledIfZeroSubscribers()
      {
         this.sut.NotifySubscribers(this.faceValue);
        
         subscriberMock.Verify(mock => mock.DieRolled(It.IsAny<int>()), Times.Exactly(0));
      }

      [Fact]
      public void NotifySubscribersShouldCallDieRolledOnEverySubscriber()
      {
        int numOfSubscrubers = 3;
        AddSubscribersToList(numOfSubscrubers);
       
        this.sut.NotifySubscribers(this.faceValue);
         
        subscriberMock.Verify(mock => mock.DieRolled(It.IsAny<int>()), 
        Times.Exactly(numOfSubscrubers));
      }

      private void AddSubscribersToList(int numOfSubscrubers)
      {
         for(int i = 0; i < numOfSubscrubers; i++)
        {
          this.sut.AddSubscriber(this.subscriberMock.Object);
        }
      }
  }
}
