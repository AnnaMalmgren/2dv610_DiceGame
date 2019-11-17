using System;
using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DiceFactoryTests
  {
      [Fact]
      public void getDieShouldReturnIDie()
      {
        DiceFactory sut = new DiceFactory();
        Assert.IsType<Die>(sut.GetDie());
      }
     
  }
}


