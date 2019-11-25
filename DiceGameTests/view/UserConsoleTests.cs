using System;
using System.IO;
using Xunit;
using Moq;
using DiceGame.view;
using System.Collections.Generic;

namespace DiceGameTests
{
  public class UserConsoleTests
  {
    private UserConsole sut;


    public UserConsoleTests()
    {
        this.sut = new UserConsole();
    }

    [Fact]
    public void writeLineShouldWriteToConsole()
    {
        StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        this.sut.WriteLine("Test input string");
        string expected = $"Test input string{Environment.NewLine}";
            
        Assert.Equal(expected, sw.ToString());       
        
    }

    [Fact]
    public void readKeyShouldReturnEnteredChar()
    {
        char expected = 'a';
        StringReader input = new StringReader(Char.ToString('a'));
        Console.SetIn(input);

        char actual = this.sut.ReadKey();

        Assert.Equal(expected, actual);

    }

    [Fact]
    public void readLineShouldReturnEnteredString()
    {
        string expected = "Test";
        StringReader input = new StringReader(expected);
        Console.SetIn(input);

        string actual = this.sut.ReadLine();

        Assert.Equal(expected, actual);
    }

  }
}