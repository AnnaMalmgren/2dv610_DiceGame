using System;
using Xunit;
using Moq;
using DiceGame.view;
using DiceGame.model;

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
      public void displayWelcomeMsgShouldWriteToConsole()
      {
        this.sut.DisplayWelcomeMsg();
        string input = "Welcome to DiceGame. Press any Key to play, or q to Quit";

        this.mockConsole.Verify(mock => mock.WriteLine(input), Times.Once());
      }

      [Fact]
      public void getUserInputShouldReturnInputChar()
      {
        this.sut.GetUserInput();

        this.mockConsole.Verify(mock => mock.ReadKey(), Times.Once());

      }

      [Fact]
      public void printDieShouldPrintFaceValueOfDie()
      {
        Mock<IDie> dieMock = new Mock<IDie>();
        dieMock.Setup(mock => mock.GetFaceValue()).Returns(5);
        this.sut.PrintDie(dieMock.Object.GetFaceValue());

        this.mockConsole.Verify(mock => mock.WriteLine($"Facevalue: 5"));
      }

      [Fact]
      public void getNrOfDicesShouldReturnNrOfDicesEntered()
      {
        this.mockConsole.Setup(mock => mock.ReadLine()).Returns("2");
        int actual = this.sut.GetNrOfDices();

        Assert.Equal(2, actual);
      }

      [Fact]
      public void getNrOfDicesShouldBeCalledAgainIfNotAnInt()
      {
        this.mockConsole.SetupSequence(mock => mock.ReadLine())
        .Returns("Hello")
        .Returns("Test")
        .Returns("4");

        this.sut.GetNrOfDices();

        this.mockConsole.Verify(mock => mock.ReadLine(), Times.Exactly(3));
      }

      [Theory]
      [InlineData('q')]
      [InlineData('Q')]
      public void userWantsToPlayShouldReturnFalseWithInputQ(char input)
      {
        this.mockConsole.Setup(mock => mock.ReadKey()).Returns(input);
        bool actual = this.sut.UserWantsToPlay();

        Assert.False(actual);
      }

      [Fact]
      public void userWantsToPlayShouldReturnTrueWhitNonQInput()
      {
        this.mockConsole.Setup(mock => mock.ReadKey()).Returns('f');
        bool actual = this.sut.UserWantsToPlay();

        Assert.True(actual);

      }

      [Fact]
      public void getGameResultsgShouldReturnYouWinString()
      {
        string actual = this.sut.GetGameResultMsg(true);

        Assert.Equal("Congratualtions you win!", actual);

      }

      [Fact]
      public void printGameResultShouldPresentGameAsLost()
      {
        this.sut.GetGameResultMsg(true);

        this.mockConsole.Verify(mock => mock.WriteLine("Sorry you lost!"), Times.Once());
      }

      [Fact]

      public void printTotalScoreShouldPrintGivenScore()
      {
        int input = 12;
        this.sut.PrintTotalScore(input);

        this.mockConsole.Verify(mock => mock.WriteLine($"Your total score is: {input}"), Times.Once());
      }

      [Fact]
      public void getScoreGuessShouldReturnEnteredInt()
      {
        this.mockConsole.Setup(mock => mock.ReadLine()).Returns("10");

        this.sut.GetScoreGuess();

        this.mockConsole.Verify(mock => mock.WriteLine(It.IsAny<string>()), Times.Once());
        this.mockConsole.Verify(mock => mock.ReadLine(), Times.Once());

      }
  
  }
}
