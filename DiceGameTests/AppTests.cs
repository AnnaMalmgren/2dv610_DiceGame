using System;
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

        public AppTests()
        {
            Mock<IMainGameView> view = new Mock<IMainGameView>();
            Mock<DiceCup> diceCup = new Mock<DiceCup>(new Mock<DiceFactory>().Object);
            this.gameMock = new Mock<PlayGameHandler>(view.Object, diceCup.Object);
            this.sut = new App(this.gameMock.Object);
        }

        [Fact]
        public void runShouldCallStartGame()
        {
            this.sut.Run();
            this.gameMock.Verify(mock => mock.StartGame(), Times.Once());
        }

    }
    
}
