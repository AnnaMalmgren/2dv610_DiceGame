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
    private Mock<DiceCupFactory> diceFactoryMock;
    private Mock<IDiceCup> diceCupMock;

    public PlayGameHandlerTests()
    {
      this.viewMock = new Mock<IMainGameView>();
      this.diceFactoryMock = new Mock<DiceCupFactory>();
      this.diceCupMock = new Mock<IDiceCup>();
      this.sut = new PlayGameHandler(viewMock.Object, diceFactoryMock.Object);

      this.viewMock.Setup(mock => mock.GetScoreGuess()).Returns(10);
    }

    [Fact]
    public void StartGameShouldReturnTrueIfUserWantsToPlay()
    {
      this.viewMock.Setup(mock => mock.UserWantsToPlay()).Returns(true);
      bool actual = this.sut.StartGame();

      Assert.True(actual);
    }

    [Fact]
    public void StartGameShouldReturnFalseIfUserDontWantToPlay()
    {
      this.viewMock.Setup(mock => mock.UserWantsToPlay()).Returns(false);
      bool actual = this.sut.StartGame();

      Assert.False(actual);
    }

    [Fact]
    public void StartGameShouldCallDisplayWelcomeMsg()
    {
      this.sut.StartGame();

      this.viewMock.Verify(mock => mock.DisplayWelcomeMsg(), Times.Once());
    }

    [Fact]
    public void PlayOneRoundShouldCallGetScoreGuess()
    {
      this.sut.PlayOneRound(this.diceCupMock.Object);
    
      viewMock.Verify(mock => mock.GetScoreGuess(), Times.Once());
    }

    [Fact]
    public void PlayOneRoundShouldCallGetOneRoundScoreWithNumDices()
    {
      int numDices = 3;
      this.viewMock.Setup(mock => mock.GetNrOfDices()).Returns(numDices);
      this.sut.PlayOneRound(this.diceCupMock.Object);
    
      diceCupMock.Verify(mock => mock.GetOneRoundScore(numDices), Times.Once());
    }

    [Fact]
    public void PlayOneRoundShouldCallDiceCupReset()
    {
      this.sut.PlayOneRound(this.diceCupMock.Object);

      diceCupMock.Verify(mock => mock.Reset(), Times.Once());
    }

    [Fact]
    public void DisplayGameResultShouldCallPrintGameResultTrue()
    {
      int totalScore = 10;
      this.diceCupMock.Setup(mock => mock.GetOneRoundScore(It.IsAny<int>())).Returns(totalScore);
      this.sut.PlayOneRound(this.diceCupMock.Object);
      this.sut.DisplayGameResult();

      this.viewMock.Verify(mock => mock.PrintGameResult(totalScore, true), Times.Once());
    }

    [Fact]
    public void DisplayGameResultShouldCallPrintGameResultFalse()
    {
      int totalScore = 12;
      this.diceCupMock.Setup(mock => mock.GetOneRoundScore(It.IsAny<int>())).Returns(totalScore);
      this.sut.PlayOneRound(this.diceCupMock.Object);
      this.sut.DisplayGameResult();

      this.viewMock.Verify(mock => mock.PrintGameResult(totalScore, false), Times.Once());
    }

    [Fact]
    public void DieRolledShouldPrintDieFaceValueWithFaceValueInt()
    {
      int diceFaceValue = 4;
      this.sut.DieRolled(diceFaceValue);
    
      this.viewMock.Verify(mock => mock.PrintDie(diceFaceValue), Times.Once());
    }

    [Fact]
    public void DiceCupShouldAddPlayGameHandlerAsSubscriber()
    {
      this.sut.PlayOneRound(this.diceCupMock.Object);

      diceCupMock.Verify(mock => mock.AddSubscriber(It.IsAny<IRollDieObserver>()), Times.Once());
    }
   
  }
}
