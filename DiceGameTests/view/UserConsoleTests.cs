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

    private StringWriter sw;

    public UserConsoleTests()
    {
        this.sut = new UserConsole();
        this.sw = new StringWriter();
    }

    [Fact]
    public void writeLineShouldWriteToConsole()
    {
        Console.SetOut(this.sw);
        sut.WriteLine("Test input string");

        string expected = $"Test input string{Environment.NewLine}";

        Assert.Equal(expected, sw.ToString());
    }


  }
}