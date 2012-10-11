using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Players;
using Monopoly.Exceptions;

namespace MonopolyTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        [ExpectedException(typeof(DuplicatePlayerAddedException))]
        public void AddingDuplicatePlayerThrowsException()
        {
            Game game = new Game();
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Horse"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayingGameWithLessThanMinimumNumberOfPlayersThrowsException()
        {
            Game game = new Game();
            game.Play();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayingGameWithGreaterThanMaximumNumberOfPlayersThrowsException()
        {
            Game game = new Game();
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Car"));
            game.AddPlayer(new Player("Iron"));
            game.AddPlayer(new Player("Ship"));
            game.AddPlayer(new Player("Thimble"));
            game.AddPlayer(new Player("Wheelbarrow"));
            game.AddPlayer(new Player("Cannon"));
            game.AddPlayer(new Player("Hat"));
            game.AddPlayer(new Player("Hokie"));
            game.Play();
        }

        [TestMethod]
        public void PlayingGameWithValidNumberOfPlayersDoesNotThrowException()
        {
            Game game = new Game();
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Car"));
            game.AddPlayer(new Player("Iron"));
            game.AddPlayer(new Player("Ship"));
            game.AddPlayer(new Player("Thimble"));
            game.AddPlayer(new Player("Wheelbarrow"));
            game.AddPlayer(new Player("Cannon"));
            game.AddPlayer(new Player("Hat"));
            game.Play();
        }

        [TestMethod]
        public void PlayExecutesSpecifiedNumberOfRounds()
        {
            Game game = new Game();
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Car"));
            game.Setup();
            game.Play();

            Assert.AreEqual(Game.MaximumNumberOfRounds, game.NumberOfRoundsPlayed);
        }
    }
}
