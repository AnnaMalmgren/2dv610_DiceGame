using System.Collections.Generic;
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
      public void startGameShouldReturnFalseIfUserDontWantToPlay()
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
      public void playOneRoundShouldGetNrOfDices()
      {
          this.sut.PlayOneRound();
          viewMock.Verify(mock => mock.GetNrOfDices(), Times.Once());
      }

      [Fact]
      public void playOneRoundShouldSetNumDicesInDiceCup()
      {
          int numDices = 3;
          this.viewMock.Setup(mock => mock.GetNrOfDices()).Returns(numDices);
          this.sut.PlayOneRound();

          diceCupMock.Verify(mock => mock.SetDice(numDices), Times.Once());
      }

    [Fact]
      public void playOneRoundShouldRollDice()
      {
          this.sut.PlayOneRound();

          diceCupMock.Verify(mock => mock.RollDice(), Times.Once());
      }

      [Fact]
      public void getWinnerShouldReturnTrueIfUserWins()
      {
          this.viewMock.Setup(mock => mock.GetScoreGuess()).Returns(10);
          this.diceCupMock.Setup(mock => mock.GetScore()).Returns(10);
          this.sut.StartGame();
          this.sut.PlayGame();

          Assert.True(this.sut.GetWinner());
      }

      [Fact]
      public void getWinnerShouldReturnFalseIfUserLost()
      {
          this.viewMock.Setup(mock => mock.GetScoreGuess()).Returns(10);
          this.diceCupMock.Setup(mock => mock.GetScore()).Returns(12);
          this.sut.StartGame();
          this.sut.PlayGame();

          Assert.False(this.sut.GetWinner());
      }

      
      [Fact]
      public void playGameShouldGetScoreGuess()
      {
          this.sut.PlayGame();

          viewMock.Verify(mock => mock.GetScoreGuess(), Times.Once());
      }

      [Fact]
      public void playGameShouldCallPrintTotalScore()
      {
          this.diceCupMock.Setup(mock => mock.GetScore()).Returns(12);
          this.sut.PlayGame();
          this.viewMock.Verify(mock => mock.PrintTotalScore(12));
      }

      [Fact]
      public void playGameShouldCallPrintGameResult()
      {
          this.sut.PlayGame();

          viewMock.Verify(mock => mock.PrintGameResult(It.IsAny<bool>()), Times.Once());
      }

       [Fact]
      public void playGameShouldCallDiceCupReset()
      {
          this.sut.PlayGame();

          diceCupMock.Verify(mock => mock.Reset(), Times.Once());
      }

      [Fact]
      public void dieRolledShouldPrintDieFaceValue()
      {
          int diceFaceValue = 4;
          this.sut.DieRolled(diceFaceValue);
          this.viewMock.Verify(mock => mock.PrintDie(It.IsAny<int>()));
      }

      [Fact]
      public void diceCupShouldAddPlayGameHandlerAsSubscriber()
      {
          diceCupMock.Verify(mock => mock.AddSubscriber(It.IsAny<IRollDieObserver>()), Times.Once());
      }
   
  }
}
