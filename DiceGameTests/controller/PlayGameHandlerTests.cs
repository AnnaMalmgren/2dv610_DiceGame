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

      private Mock<IDiceCup> diceCupMock;

      public PlayGameHandlerTests()
      {
          this.viewMock = new Mock<IMainGameView>();
          this.diceCupMock = new Mock<IDiceCup>();
          this.sut = new PlayGameHandler(viewMock.Object, diceCupMock.Object);

          this.viewMock.Setup(mock => mock.GetScoreGuess()).Returns(10);
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
      public void playOneRoundShouldGetScoreGuess()
      {
          this.sut.PlayOneRound();

          viewMock.Verify(mock => mock.GetScoreGuess(), Times.Once());
      }

      [Fact]
      public void playOneRoundShouldCallDiceCupGetOneRoundScore()
      {
          int numDices = 3;
          this.viewMock.Setup(mock => mock.GetNrOfDices()).Returns(numDices);
          this.sut.PlayOneRound();
          diceCupMock.Verify(mock => mock.GetOneRoundScore(numDices), Times.Once());
      }


      [Fact]
      public void displayGameResultShouldCallPrintGameResultTrue()
      {
           int totalScore = 10;
           this.diceCupMock.Setup(mock => mock.GetOneRoundScore(It.IsAny<int>())).Returns(totalScore);
           this.sut.PlayOneRound();
           this.sut.DisplayGameResult();

          this.viewMock.Verify(mock => mock.PrintGameResult(totalScore, true), Times.Once());
      }

      [Fact]
      public void displayGameResultShouldCallPrintGameResultFalse()
      {
           int totalScore = 12;
           this.diceCupMock.Setup(mock => mock.GetOneRoundScore(It.IsAny<int>())).Returns(totalScore);
           this.sut.PlayOneRound();
           this.sut.DisplayGameResult();

          this.viewMock.Verify(mock => mock.PrintGameResult(totalScore, false), Times.Once());
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
          this.viewMock.Verify(mock => mock.PrintDie(It.IsAny<int>()), Times.Once());
      }

      [Fact]
      public void diceCupShouldAddPlayGameHandlerAsSubscriber()
      {
          diceCupMock.Verify(mock => mock.AddSubscriber(It.IsAny<IRollDieObserver>()), Times.Once());
      }
   
  }
}
