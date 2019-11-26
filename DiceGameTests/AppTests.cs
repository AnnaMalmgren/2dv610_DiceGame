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
            Mock<IDiceCup> diceCup = new Mock<IDiceCup>();
            this.gameMock = new Mock<PlayGameHandler>(view.Object, diceCup.Object);
            this.sut = new App(this.gameMock.Object);
        }

        private void SetUpForRunWhileLoopOnce()
        {
            this.gameMock.SetupSequence(mock => mock.StartGame())
            .Returns(true)
            .Returns(false);
        }

        [Fact]
        public void runShouldCallStartGameOnlyOnceIfCalledWithFalse()
        {
            this.gameMock.Setup(mock => mock.StartGame()).Returns(false);
            this.sut.Run();
            this.gameMock.Verify(mock => mock.StartGame(), Times.Once());
        }

        [Fact]
        public void runShouldCallStartGameTwiceForOneRound()
        {
            SetUpForRunWhileLoopOnce();
            this.sut.Run();
            this.gameMock.Verify(mock => mock.StartGame(), Times.Once());
        }

        [Fact]
        public void runShouldCallPlayGameOnceForOneRound()
        {
            SetUpForRunWhileLoopOnce();
            this.sut.Run();
            this.gameMock.Verify(mock => mock.PlayGame(), Times.Once());
        }

        [Fact]
        public void runShouldCallPlayGameWhileStartGameIsTrue()
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
