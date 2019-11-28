using Xunit;
using DiceGame.model;

namespace DiceGameTests
{
  public class DiceFactoryTests
  {
    [Fact]
    public void GetDieShouldReturnDieInstance()
    {
      DieFactory sut = new DieFactory();
      Assert.IsType<Die>(sut.GetDie());
    }
  }
}


