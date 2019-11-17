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

    public DiceCupTest()
    {
      this.factoryMock = new Mock<DiceFactory>();
      this.dieMock = new Mock<IDie>();

      this.factoryMock.Setup(mock => mock.getDie()).Returns(new Mock<IDie>().Object);
      this.dieMock.Setup(mock => mock.RollDie());
    }

      [Theory]
      [InlineData(0)]
      [InlineData(1)]
      [InlineData(5)]
      public void factoryGetDieShoulbBeCalledForAllDice(int nrOfDice)
      {
        DiceCup sut = new DiceCup(this.factoryMock.Object);
        sut.SetDice(nrOfDice);
        this.factoryMock.Verify(mock => mock.getDie(), Times.Exactly(nrOfDice));
      }

      [Theory]
      [InlineData(0)]
      [InlineData(3)]
      [InlineData(5)]
      public void rollDieShoulbBeCalledForAllDice(int nrOfDice)
      {
        this.factoryMock.Setup(mock => mock.getDie()).Returns(dieMock.Object);
        DiceCup sut = new DiceCup(this.factoryMock.Object);
        sut.SetDice(nrOfDice);
        sut.RollDice();
        this.dieMock.Verify(mock => mock.RollDie(), Times.Exactly(nrOfDice));
      }


  }
}
