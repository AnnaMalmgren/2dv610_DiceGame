using Xunit;
using DiceGame.model;

namespace DiceGameTests
{
  public class DiceCupFactoryTests
  {
    [Fact]
    public void GetDiceCupShouldReturnDiceCupInstance()
    {
      DiceCupFactory sut = new DiceCupFactory();
      Assert.IsType<DiceCup>(sut.GetDiceCup());
    }
     
  }
}