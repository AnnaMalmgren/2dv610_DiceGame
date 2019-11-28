using Xunit;
using Moq;
using DiceGame.view;

namespace DiceGameTests
{
  public class GameViewTests
  {
    private Mock<IUserConsole> mockConsole;
    private GameView sut;

    public GameViewTests()
    {
      this.mockConsole = new Mock<IUserConsole>();
      this.sut = new GameView(this.mockConsole.Object);
    }

      [Fact]
      public void DisplayWelcomeMsgShouldWriteMsgToConsole()
      {
        this.sut.DisplayWelcomeMsg();
        string input = "Welcome to DiceGame. Press any Key to play, or q to Quit";

        this.mockConsole.Verify(mock => mock.WriteLine(input), Times.Once());
      }

      [Fact]
      public void GetUserInputShouldReturnInputChar()
      {
        this.sut.GetUserInput();

        this.mockConsole.Verify(mock => mock.ReadKey(), Times.Once());
      }

      [Fact]
      public void PrintDieShouldPrintFaceValueOfDie()
      {
        int faceValue = 5;
        this.sut.PrintDie(faceValue);

        this.mockConsole.Verify(mock => mock.WriteLine($"Facevalue: 5"));
      }

      [Fact]
      public void GetNrOfDicesShouldReturnInputEnteredByUser()
      {
        this.mockConsole.Setup(mock => mock.ReadLine()).Returns("2");
        int actual = this.sut.GetNrOfDices();

        Assert.Equal(2, actual);
      }

      [Fact]
      public void GetNrOfDiceShouldBeCalledAgainIfInputIsNotAnInt()
      {
        this.mockConsole.SetupSequence(mock => mock.ReadLine())
        .Returns("Hello")
        .Returns("Test")
        .Returns("4");

        this.sut.GetNrOfDices();

        this.mockConsole.Verify(mock => mock.ReadLine(), Times.Exactly(3));
      }

      [Fact]
      public void UserWantsToPlayShouldReturnFalseWithInputCapitalQ()
      {
        this.mockConsole.Setup(mock => mock.ReadKey()).Returns('Q');
        bool actual = this.sut.UserWantsToPlay();

        Assert.False(actual);
      }

      [Fact]
      public void UserWantsToPlayShouldReturnFalseWithInputLowerCaseQ()
      {
        this.mockConsole.Setup(mock => mock.ReadKey()).Returns('q');
        bool actual = this.sut.UserWantsToPlay();

        Assert.False(actual);
      }

      [Fact]
      public void UserWantsToPlayShouldReturnTrueWhitNonQInput()
      {
        this.mockConsole.Setup(mock => mock.ReadKey()).Returns('f');
        bool actual = this.sut.UserWantsToPlay();

        Assert.True(actual);
      }

      [Fact]
      public void PrintGameResultShouldPrintGivenScore()
      {
        int inputScore = 10;
        sut.PrintGameResult(inputScore, true);

        this.mockConsole.Verify(mock => mock.WriteLine($"Your total score is: {inputScore}"),
        Times.Once());
      }

      [Fact]
      public void PrintGameResultShouldPrintYouWinMsgWhengivenTrue()
      {
        sut.PrintGameResult(10, true);

        this.mockConsole.Verify(mock => mock.WriteLine($"Congratualtions you win!"),
        Times.Once());
      }

      [Fact]
      public void PrintGameResultShouldPrintYouLostMsgWhengivenFalse()
      {
        sut.PrintGameResult(10, false);

        this.mockConsole.Verify(mock => mock.WriteLine($"Sorry you lost!"),
        Times.Once());
      }

      [Fact]
      public void GetScoreGuessShouldReturnEnteredInt()
      {
        this.mockConsole.Setup(mock => mock.ReadLine()).Returns("10");
        int actual = this.sut.GetScoreGuess();

        Assert.Equal(10, actual);
      }
  }
}
