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
      public void displayMainMenuShouldWriteMainMenuToConsole()
      {
        var mockConsole = new Mock<IUserConsole>();
        GameView sut = new GameView(mockConsole.Object);

        sut.DisplayMainMenu();
        string menu = "Main Menu";

        mockConsole.Verify(mock => mock.WriteLine(menu), Times.Once());
      }
  
  }
}
