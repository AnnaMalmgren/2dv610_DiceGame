using System;
using Xunit;
using Moq;
using DiceGame.model;
using System.Collections.Generic;

namespace DiceGameTests
{
  public class DiceCupTest
  {
    private Mock<DiceFactory> factoryMock;
    private Mock<IDie> dieMock;

    private DiceCup sut;

    public DiceCupTest()
    {
      this.factoryMock = new Mock<DiceFactory>();
      this.dieMock = new Mock<IDie>();
      this.sut = new DiceCup(this.factoryMock.Object);

      this.factoryMock.Setup(mock => mock.getDie()).Returns(this.dieMock.Object);
      this.dieMock.Setup(mock => mock.RollDie());
      this.dieMock.Setup(mock => mock.GetFaceValue()).Returns(5);
    }

      [Theory]
      [InlineData(0)]
      [InlineData(1)]
      [InlineData(5)]
      public void factoryGetDieShoulbBeCalledForAllDice(int nrOfDice)
      {
        this.sut.SetDice(nrOfDice);
        this.factoryMock.Verify(mock => mock.getDie(), Times.Exactly(nrOfDice));
      }

      [Theory]
      [InlineData(0)]
      [InlineData(3)]
      [InlineData(5)]
      public void rollDieShoulbBeCalledForAllDice(int nrOfDice)
      {
        this.sut.SetDice(nrOfDice);
        this.sut.RollDice();
        this.dieMock.Verify(mock => mock.RollDie(), Times.Exactly(nrOfDice));
      }
      
      [Fact]
      public void getScoreShouldReturnFaceValueOfDie()
      {
        this.sut.SetDice(1);
        this.sut.RollDice();
        int actual = this.sut.GetScore();

        Assert.Equal(5, actual);

      }

      [Fact]
      public void getScoreShouldReturnFaceValuesOfAllDice()
      {
        this.sut.SetDice(5);
        this.sut.RollDice();
        int actual = this.sut.GetScore();

        Assert.Equal(25, actual);

      }


  }
}
