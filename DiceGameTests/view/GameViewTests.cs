using System;
using Xunit;
using Moq;
using DiceGame.view;
using DiceGame.model;
using System.Collections.Generic;

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
      public void getNrOfDicesShouldReturnNrOfDicesEntered()
      {
        this.mockConsole.Setup(mock => mock.ReadLine()).Returns("2");
        int actual = this.sut.GetNrOfDices();

        Assert.Equal(2, actual);
      }

      [Fact]
      public void getNrOfDicesShouldThrowExceptionWhenNotAInt()
      {
        this.mockConsole.Setup(mock => mock.ReadLine()).Returns("Hello");

        Assert.Throws<ArgumentException>(() => this.sut.GetNrOfDices());

      }

      [Theory]
      [InlineData(4)]
      [InlineData(2)]
      public void printDieShouldPrintFaceValueOfDie(int faceValue)
      {
        Mock<IDie> dieMock = new Mock<IDie>();
        dieMock.Setup(mock => mock.GetFaceValue()).Returns(faceValue);
        this.sut.PrintDie(dieMock.Object);

        this.mockConsole.Verify(mock => mock.WriteLine($"Facevalue: {faceValue}"));
      }

      [Fact]
      public void printDiceResultShouldPrintValueForOneDie()
      {
        Mock<IDie> dieMock = new Mock<IDie>();
        dieMock.Setup(mock => mock.GetFaceValue()).Returns(2);
        List<IDie> diceCup = new List<IDie>(){dieMock.Object};
        
        this.sut.PrintDiceResult(diceCup, 2);
        
        string expectedDie = "Facevalue: 2";
        string expectedScore = $"Total Score: 2";
        this.mockConsole.Verify(mock => mock.WriteLine(expectedDie));
        this.mockConsole.Verify(mock => mock.WriteLine(expectedScore));
      }

      [Fact]
      public void printDiceResultShouldPrintValueForMultipleDice()
      {
        Mock<IDie> dieMock = new Mock<IDie>();
        Mock<IDie> dieMock2 = new Mock<IDie>();
        Mock<IDie> dieMock3 = new Mock<IDie>();
        dieMock.Setup(mock => mock.GetFaceValue()).Returns(2);
        dieMock2.Setup(mock => mock.GetFaceValue()).Returns(4);
        dieMock3.Setup(mock => mock.GetFaceValue()).Returns(4);
        List<IDie> diceCup = new List<IDie>(){dieMock.Object, dieMock2.Object, dieMock3.Object};
        
        this.sut.PrintDiceResult(diceCup, 10);
        
        this.mockConsole.Verify(mock => mock.WriteLine(It.IsAny<string>()), Times.Once());
  
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
      public void printGameResultShouldPresentUserAsWinner()
      {
        this.sut.PrintGameResult(true);

        this.mockConsole.Verify(mock => mock.WriteLine("Congratualtions you win!"));

      }

      [Fact]
      public void printGameResultShouldPresentGameAsLost()
      {
        this.sut.PrintGameResult(false);

        this.mockConsole.Verify(mock => mock.WriteLine("Sorry you lost!"));

      }
  
  }
}
