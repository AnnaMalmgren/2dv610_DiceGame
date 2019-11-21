using System;
using Xunit;
using Moq;
using DiceGame.view;
using DiceGame.model;
using DiceGame.controller;


namespace DiceGameTests
{
  public class PlayGameHandlerTests
  {
      private PlayGameHandler sut;

      private Mock<IMainGameView> viewMock;

      public PlayGameHandlerTests()
      {
          this.viewMock = new Mock<IMainGameView>();
          this.sut = new PlayGameHandler(viewMock.Object);
      }

      [Fact]
      public void playGameShouldGetWelcomeMessage()
      {
          this.sut.PlayGame();

          this.viewMock.Verify(mock => mock.DisplayWelcomeMsg(), Times.Once());
      }

      [Fact]
      public void playGameShouldCallGetNrOfDices()
      {
          this.sut.PlayGame();

          this.viewMock.Verify(mock => mock.GetNrOfDices(), Times.Once());
      }

   
   
  
  }
}
