using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Classic;

namespace MonopolyTests
{
    [TestClass]
    public class GameTests
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            this.game = new ClassicGame();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingDuplicatePlayerThrowsException()
        {
            this.game.AddPlayer(new Player("Horse"));
            this.game.AddPlayer(new Player("Horse"));
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlayingGameWithLessThanMinimumNumberOfPlayersThrowsException()
        {
            this.game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlayingGameWithGreaterThanMaximumNumberOfPlayersThrowsException()
        {
            this.game.AddPlayer(new Player("Horse"));
            this.game.AddPlayer(new Player("Car"));
            this.game.AddPlayer(new Player("Iron"));
            this.game.AddPlayer(new Player("Ship"));
            this.game.AddPlayer(new Player("Thimble"));
            this.game.AddPlayer(new Player("Wheelbarrow"));
            this.game.AddPlayer(new Player("Cannon"));
            this.game.AddPlayer(new Player("Hat"));
            this.game.AddPlayer(new Player("Hokie"));
            this.game.Start();
        }

        [TestMethod]
        public void PlayingGameWithValidNumberOfPlayersDoesNotThrowException()
        {
            this.game.AddPlayer(new Player("Horse"));
            this.game.AddPlayer(new Player("Car"));
            this.game.AddPlayer(new Player("Iron"));
            this.game.AddPlayer(new Player("Ship"));
            this.game.AddPlayer(new Player("Thimble"));
            this.game.AddPlayer(new Player("Wheelbarrow"));
            this.game.AddPlayer(new Player("Cannon"));
            this.game.AddPlayer(new Player("Hat"));
            this.game.Start();
        }

        [TestMethod]
        public void PlayExecutesSpecifiedNumberOfRounds()
        {
            this.game.AddPlayer(new Player("Horse"));
            this.game.AddPlayer(new Player("Car"));
            GameController controller = new GameController(this.game);
            controller.Play();

            Assert.AreEqual(GameController.NumberOfRoundsToPlay, this.game.NumberOfRoundsPlayed);
        }

        [TestMethod]
        public void PlayExecutesSamePlayerOrderInEachRound()
        {
            this.game.AddPlayer(new Player("Horse"));
            this.game.AddPlayer(new Player("Car"));
            this.game.AddPlayer(new Player("Hat"));

            GameController controller = new GameController(this.game);
            controller.Play();

            Round lastRound = null;

            foreach (Round currentRound in this.game.Rounds)
            {
                if (lastRound != null)
                {
                    IEnumerable<Player> currentRoundPlayerRolls = currentRound.Players;
                    IEnumerable<Player> lastRoundPlayerRolls = lastRound.Players;

                    for (Int32 i = 0; i < lastRound.NumberOfPlayers; i++)
                        Assert.AreEqual(currentRoundPlayerRolls.ElementAt(i), lastRoundPlayerRolls.ElementAt(i));
                }

                lastRound = currentRound;
            }
        }
    }
}
