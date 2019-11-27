using System;
using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DiceFactoryTests
  {
      [Fact]
      public void getDieShouldReturnTypeDie()
      {
        DieFactory sut = new DieFactory();
        Assert.IsType<Die>(sut.GetDie());
      }
     
  }
}


