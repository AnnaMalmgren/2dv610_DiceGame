using System;
using Xunit;
using Moq;
using DiceGame.view;
using DiceGame.model;
using System.Collections.Generic;

namespace DiceGameTests
{
  public class DiceViewTests
  {
      private DiceView sut; 

      private Mock<IUserConsole> mockConsole;

      private List<IDie> diceCup;

      private IReadOnlyList<IDie> DiceCup => this.diceCup.AsReadOnly();


      public DiceViewTests()
      {
        this.mockConsole = new Mock<IUserConsole>();
        this.sut = new DiceView(this.mockConsole.Object);
        this.diceCup = new List<IDie>();
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
        this.diceCup.Add(dieMock.Object);
        
        this.sut.PrintDiceResult(DiceCup);
        
        string expectedDie = "Facevalue: 2";
        this.mockConsole.Verify(mock => mock.WriteLine(expectedDie), Times.Once());
      }

      [Fact]
      public void printDiceResultShouldPrintValueForMultipleDice()
      {
        this.diceCup.Add(new Mock<IDie>().Object);
        this.diceCup.Add(new Mock<IDie>().Object);
        this.diceCup.Add(new Mock<IDie>().Object);
        
        this.sut.PrintDiceResult(DiceCup);
        
        this.mockConsole.Verify(mock => mock.WriteLine(It.IsAny<string>()), Times.Exactly(3));
  
      }
  }
}