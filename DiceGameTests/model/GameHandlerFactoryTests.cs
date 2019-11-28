using Xunit;
using DiceGame.model;
using DiceGame.controller;

namespace DiceGameTests
{
  public class GameHandlerFactoryTests
  {
    [Fact]
    public void GetPlayGameHandlerShouldReturnPlayGameHandlerInstance()
    {

      GameHandlerFactory sut = new GameHandlerFactory();  

      Assert.IsType<PlayGameHandler>(sut.GetPlayGameHandler());
    }
     
  }
}