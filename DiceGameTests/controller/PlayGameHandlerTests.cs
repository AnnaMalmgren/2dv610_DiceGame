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
      public void startGameShouldReturnTrueIfUserWantsToPlay()
      {
          this.viewMock.Setup(mock => mock.UserWantsToPlay()).Returns(true);
          bool actual = this.sut.StartGame();

          Assert.True(actual);
      }

      [Fact]
      public void startGameShouldReturnFalseIfUserWantsToPlay()
      {
          this.viewMock.Setup(mock => mock.UserWantsToPlay()).Returns(false);
          bool actual = this.sut.StartGame();

          Assert.False(actual);
      }

      [Fact]
      public void startGameShouldGetWelcomeMessage()
      {
          this.sut.StartGame();

          this.viewMock.Verify(mock => mock.DisplayWelcomeMsg(), Times.Once());
      }


      [Fact]
      public void playOneRoundShouldSetNumDicesInDiceCup()
      {
          int numDices = 3;
          this.sut.PlayOneRound(numDices);

          diceCupMock.Verify(mock => mock.SetDice(numDices), Times.Once());
      }

    [Fact]
      public void playOneRoundShouldRollDice()
      {
          int numDices = 3;
          this.sut.PlayOneRound(numDices);

          diceCupMock.Verify(mock => mock.RollDice(), Times.Once());
      }

      [Fact]
      public void playOneRoundShouldReturnScore()
      {
          int numDices = 3;
          diceCupMock.Setup(mock => mock.GetScore()).Returns(16);
          int actual = this.sut.PlayOneRound(numDices);

          Assert.Equal(16, actual);

      }

      [Fact]
      public void getWinnerShouldReturnTrueIfUserWins()
      {
          this.viewMock.Setup(mock => mock.GetScoreGuess()).Returns(10);
          this.sut.PlayGame();
          this.sut.StartGame();

          Assert.True(this.sut.GetWinner(10));
      }

      [Fact]
      public void getWinnerShouldReturnFalseIfUserLost()
      {
          this.viewMock.Setup(mock => mock.GetScoreGuess()).Returns(10);
          this.sut.PlayGame();

          Assert.False(this.sut.GetWinner(12));
      }

      [Fact]
      public void playGameShouldGetNrOfDices()
      {
          this.sut.PlayGame();

          viewMock.Verify(mock => mock.GetNrOfDices(), Times.Once());
      }

      [Fact]
      public void playGameShouldGetScoreGuess()
      {
          this.sut.PlayGame();

          viewMock.Verify(mock => mock.GetScoreGuess(), Times.Once());
      }

      [Fact]
      public void playGameShouldCallPrintGameResult()
      {
          this.sut.PlayGame();

          viewMock.Verify(mock => mock.PrintGameResult(It.IsAny<bool>()), Times.Once());
      }


   
  }
}
