using System;
using System.IO;
using Xunit;
using DiceGame.view;

namespace DiceGameTests
{
  public class UserConsoleTests
  {
    private UserConsole sut;
    private string stringInput = "Test input string";
    private char charInput = 'a';

    public UserConsoleTests()
    {
      this.sut = new UserConsole();
    }

    [Fact]
    public void WriteLineShouldWriteToConsole()
    {
      StringWriter sw = new StringWriter();
      Console.SetOut(sw);
      this.sut.WriteLine(this.stringInput);
      string expected = $"{this.stringInput}{Environment.NewLine}";
            
      Assert.Equal(expected, sw.ToString());       
    }

    [Fact]
    public void ReadKeyShouldReturnEnteredChar()
    {
      StringReader input = new StringReader(Char.ToString(this.charInput));
      Console.SetIn(input);
      char actual = this.sut.ReadKey();

      Assert.Equal(this.charInput, actual);
    }

    [Fact]
    public void ReadLineShouldReturnEnteredString()
    {
      StringReader input = new StringReader(this.stringInput);
      Console.SetIn(input);
      string actual = this.sut.ReadLine();

      Assert.Equal(this.stringInput, actual);
    }

  }
}