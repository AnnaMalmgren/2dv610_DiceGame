using System;
using Xunit;
using Moq;
using DiceGame.view;
using System.Collections.Generic;

namespace DiceGameTests
{
  public class GameViewTests
  {
      [Fact]
      public void displayWelcomeMsgShouldWriteToConsole()
      {
        var mockConsole = new Mock<IUserConsole>();
        GameView sut = new GameView(mockConsole.Object);

        sut.DisplayWelcomeMsg();
        string input = "Welcome Msg";

        mockConsole.Verify(mock => mock.WriteLine(input), Times.Once());
      }
  
  }
}
