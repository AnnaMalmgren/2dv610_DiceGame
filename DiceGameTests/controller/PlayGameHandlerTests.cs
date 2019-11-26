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

          this.viewMock.SetupSequence(mock => mock.UserWantsToPlay())
          .Returns(true)
          .Returns(false);
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
      public void getWinnerShouldReturnTrueIfUserWins()
      {
          this.viewMock.Setup(mock => mock.GetScoreGuess()).Returns(10);
          this.diceCupMock.Setup(mock => mock.GetOneRoundScore(It.IsAny<int>())).Returns(10);
          this.sut.PlayOneRound();

          Assert.True(this.sut.GetWinner());
      }

      [Fact]
      public void getWinnerShouldReturnFalseIfUserLost()
      {
          this.viewMock.Setup(mock => mock.GetScoreGuess()).Returns(10);
           this.diceCupMock.Setup(mock => mock.GetOneRoundScore(It.IsAny<int>())).Returns(12);
          this.sut.PlayOneRound();

          Assert.False(this.sut.GetWinner());
      }

      [Fact]
      public void playGameShouldCallPrintGameResult()
      {
          this.sut.PlayGame();
          this.viewMock.Verify(mock => mock.PrintGameResult(It.IsAny<int>(), It.IsAny<bool>()));
      }


      [Fact]
      public void playGameShouldCallDiceCupReset()
      {
          this.sut.PlayGame();

          diceCupMock.Verify(mock => mock.Reset(), Times.Once());
      }

      [Fact]
      public void playGameShouldContinueWhileStartGameReturnsTrue()
      {
          this.viewMock.SetupSequence(mock => mock.UserWantsToPlay())
          .Returns(true)
          .Returns(true)
          .Returns(false);

          this.sut.PlayGame();

          diceCupMock.Verify(mock => mock.Reset(), Times.Exactly(2));
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
