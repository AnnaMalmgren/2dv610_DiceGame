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
          var cup = new Mock<DiceCup>();

          var view = new Mock<GameView>();

          this.sut.PlayGame(cup.Object, view.Object);

          view.Verify(v => v.DisplayWelcomeMsg(), Times.Once());

      }
   
  
  }
}
