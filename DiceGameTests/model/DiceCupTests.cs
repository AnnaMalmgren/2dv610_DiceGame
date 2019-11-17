using System;
using Xunit;
using Moq;
using DiceGame.model;
using System.Collections.Generic;

namespace DiceGameTests
{
  public class DiceCupTest
  {

      [Fact]
      public void factoryGetDieShoulbBeCalledForAllDice()
      {
        var factoryMock = new Mock<DiceFactory>();
        factoryMock.Setup(mock => mock.getDie()).Returns(new Mock<IDie>().Object);
        DiceCup sut = new DiceCup(factoryMock.Object);
        sut.SetDice(3);
        factoryMock.Verify(mock => mock.getDie(), Times.Exactly(3));
      }


  }
}
