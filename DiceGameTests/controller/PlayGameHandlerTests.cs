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

      private Mock<DiceCup> diceCupMock;

      public PlayGameHandlerTests()
      {
          this.viewMock = new Mock<IMainGameView>();
          this.diceCupMock = new Mock<DiceCup>(new Mock<DiceFactory>().Object);
          this.sut = new PlayGameHandler(viewMock.Object, diceCupMock.Object);
      }

      [Fact]
      public void startGameShouldGetWelcomeMessage()
      {
          this.sut.StartGame();

          this.viewMock.Verify(mock => mock.DisplayWelcomeMsg(), Times.Once());
      }

      [Fact]
      public void startGameShouldCallGetNrOfDices()
      {
          this.sut.StartGame();

          this.viewMock.Verify(mock => mock.GetNrOfDices(), Times.Once());
      }

      [Fact]
      public void playGameShouldSetNumDicesInDiceCup()
      {
          int numDices = 3;
          this.sut.PlayGame(numDices);

          diceCupMock.Verify(mock => mock.SetDice(numDices), Times.Once());
      }

    [Fact]
      public void playGameShouldRollDice()
      {
          int numDices = 3;
          this.sut.PlayGame(numDices);

          diceCupMock.Verify(mock => mock.RollDice(), Times.Once());
      }
  
  }
}
