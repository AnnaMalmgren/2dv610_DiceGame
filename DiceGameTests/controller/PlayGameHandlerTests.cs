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
      public void playOneRoundShouldGetScore()
      {
          int numDices = 3;
          this.sut.PlayOneRound(numDices);

          diceCupMock.Verify(mock => mock.GetScore(), Times.Once());
      }

      [Theory]
      [InlineData(10)]
      [InlineData(4)]
      public void GetWinnerShouldReturnTrueIfUserWins(int score)
      {
          this.viewMock.Setup(mock => mock.GetScoreGuess()).Returns(score);
          this.sut.StartGame();

          Assert.True(this.sut.GetWinner(score));
      }

      [Fact]
      public void GetWinnerShouldReturnFalseIfUserLost()
      {
          this.viewMock.Setup(mock => mock.GetScoreGuess()).Returns(10);
          this.sut.StartGame();

          Assert.False(this.sut.GetWinner(12));
      }

      [Fact]
      public void playGameShould()
      {
          
      }


  }
}
