using Xunit;
using Moq;
using DiceGame;
using DiceGame.controller;
using DiceGame.view;
using DiceGame.model;

namespace DiceGameTests
{
  public class AppTests
  {
    private App sut;
    private Mock<PlayGameHandler> gameMock;

    private Mock<GameHandlerFactory> gameFactory;

    public AppTests()
    {
      this.gameFactory = new Mock<GameHandlerFactory>();
      Mock<IMainGameView> view = new Mock<IMainGameView>();
      Mock<DiceCupFactory> dices = new Mock<DiceCupFactory>();
      this.gameMock = new Mock<PlayGameHandler>(view.Object, dices.Object);
      
      gameFactory.Setup(mock => mock.GetPlayGameHandler())
      .Returns(this.gameMock.Object);

      this.sut = new App(gameFactory.Object);
    }

    private void SetUpForRunWhileLoopOnce()
    {
      this.gameMock.SetupSequence(mock => mock.StartGame())
      .Returns(true)
      .Returns(false);
    }

    [Fact]
    public void SutShouldCallGetPlayGameHandler()
    {
        this.gameFactory.Verify(mock => mock.GetPlayGameHandler(), Times.Once());
    }

    [Fact]
    public void RunShouldCallStartGameOnlyOnceIfCalledWithFalse()
    {
      this.gameMock.Setup(mock => mock.StartGame()).Returns(false);
      this.sut.Run();

      this.gameMock.Verify(mock => mock.StartGame(), Times.Once());
    }

    [Fact]
    public void RunShouldCallStartGameTwiceForOneRound()
    {
      SetUpForRunWhileLoopOnce();
      this.sut.Run();
    
      this.gameMock.Verify(mock => mock.StartGame(), Times.Exactly(2));
    }

    [Fact]
    public void RunShouldCallPlayGameOnceForOneRound()
    {
      SetUpForRunWhileLoopOnce();
      this.sut.Run();

      this.gameMock.Verify(mock => mock.PlayGame(), Times.Once());
    }

    [Fact]
    public void RunShouldCallPlayGameWhileStartGameIsTrue()
    {
      this.gameMock.SetupSequence(mock => mock.StartGame())
      .Returns(true)
      .Returns(true)
      .Returns(true)
      .Returns(false);

      this.sut.Run();

      this.gameMock.Verify(mock => mock.PlayGame(), Times.Exactly(3));
    }
  } 
}
