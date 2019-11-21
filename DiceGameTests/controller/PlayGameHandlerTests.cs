using System;
using Xunit;
using Moq;
using DiceGame.view;
using DiceGame.model;
using DiceGame.controller;
using System.Collections.Generic;

namespace DiceGameTests
{
  public class PlayGameHandlerTests
  {
      private PlayGameHandler sut;

      public PlayGameHandlerTests()
      {
          this.sut = new PlayGameHandler();
      }

      [Fact]
      public void playGameShouldGetWelcomeMessage()
      {

          var view = new Mock<GameView>(new UserConsole());

          this.sut.PlayGame(view.Object);

          view.Verify(v => v.DisplayWelcomeMsg(), Times.Once());

      }
   
  
  }
}
