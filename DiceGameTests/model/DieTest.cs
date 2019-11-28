using System;
using Xunit;
using Moq;
using DiceGame.model;

namespace DiceGameTests
{
  public class DieTest
  {
    private Die sut;
    private Mock<Random> randMock;

    public DieTest()
    {
      this.randMock = new Mock<Random>();
      this.sut = new Die(this.randMock.Object);
    }

    [Fact]
    public void SidesOfDieDefaultShouldBeSix()
    {
      int actual = this.sut.Sides;

      Assert.Equal(6, actual);
    }

    [Fact]
    public void SidesOfDieShouldBeAssignedInputInt()
    {
      int inputSides = 4;
      Die sut = new Die(this.randMock.Object, inputSides);
      int actual = sut.Sides;

      Assert.Equal(inputSides, actual);
    }

    [Fact]
    public void DieThrowsArgumentExceptionIfSidesAreLessThanFour()
    {
      Assert.Throws<ArgumentException>(() => new Die(this.randMock.Object, 3));
    }

    [Fact]
    public void DieThrowsArgumentExceptionIfSidesAreMoreThanTwelve()
    {
      Assert.Throws<ArgumentException>(() => new Die(this.randMock.Object, 13));
    }

    [Fact]
    public void DieThrowsArgumentExceptionIfSidesAreUnEven()
    {
      Assert.Throws<ArgumentException>(() => new Die(this.randMock.Object, 5));
    }

    [Fact]
    public void GetFaceValueShouldReturnValueInExpectedRange()
    {
      Die sut = new Die(new Random());
      sut.RollDie();
      int actual = sut.GetFaceValue();

      Assert.InRange<int>(actual, 1, 6);
    }

    [Fact]
    public void GetFaceValueShouldReturnSpecificValueFromRandom()
    {
      int returnFromRandom = 6;
      this.randMock.Setup(m => m.Next(1, 7)).Returns(returnFromRandom);
      this.sut.RollDie();
      int actual = this.sut.GetFaceValue();

      Assert.Equal(returnFromRandom, actual);
    }

    [Fact]
    public void GetFaceValueShouldBeTheSameWhenDieNotRolled()
    {
      this.randMock.Setup(m => m.Next(1, 7)).Returns(5);
      this.sut.RollDie();

      int value1 = this.sut.GetFaceValue();
      int value2 = this.sut.GetFaceValue();

      Assert.Equal(value1, value2);
    }
  }
}


