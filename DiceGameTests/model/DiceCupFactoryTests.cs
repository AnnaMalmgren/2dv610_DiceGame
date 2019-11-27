using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DiceCupFactoryTests
  {
      [Fact]
      public void getDiceCupShouldReturnDiceCup()
      {
        DiceCupFactory sut = new DiceCupFactory();
        Assert.IsType<DiceCup>(sut.GetDiceCup());
      }
     
  }
}