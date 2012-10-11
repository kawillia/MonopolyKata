using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board.Locations;
using Monopoly.Board.Locations.Properties;
using Monopoly.Classic;
using Monopoly.Strategies;

namespace MonopolyTests.Board.Locations
{
    [TestClass]
    public class GoTests
    {
        private Player horse;
        private Go go;
        private Int32 currentDiceValue;

        public GoTests()
        {
            horse = new Player("Horse", 1500);
            go = new Go(ClassicBoard.GoLocation, ClassicBoard.GoSalaryBonus);
            currentDiceValue = 7;
        }

        [TestMethod]
        public void PlayerLandingOnGoIncreasesPlayerBalanceByGoSalaryBonus()
        {
            go.LandedOnByPlayer(horse, currentDiceValue);

            Assert.AreEqual(1500 + ClassicBoard.GoSalaryBonus, horse.Balance);
        }

        [TestMethod]
        public void PlayerPassingGoIncreasesPlayerBalanceByGoSalaryBonus()
        {
            go.PassedByPlayer(horse, currentDiceValue);

            Assert.AreEqual(1500 + ClassicBoard.GoSalaryBonus, horse.Balance);
        }

        [TestMethod]
        public void PlayerPassingGoTwiceIncreasesPlayerBalanceByTwoTimesTheGoSalaryBonus()
        {
            go.PassedByPlayer(horse, currentDiceValue);
            go.PassedByPlayer(horse, currentDiceValue);

            Assert.AreEqual(1500 + (2 * ClassicBoard.GoSalaryBonus), horse.Balance);
        }
    }
}
