using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.Board.Locations;
using Monopoly;
using Monopoly.Classic;
using System;

namespace MonopolyTests.Board
{
    [TestClass]
    public class IncomeTaxTests
    {
        private Player horse;
        private IncomeTax incomeTax;
        private Int32 currentDiceValue;

        public IncomeTaxTests()
        {
            incomeTax = new IncomeTax(ClassicBoard.IncomeTaxLocation, ClassicBoard.IncomeTaxPercentage, ClassicBoard.MaximumIncomeTaxPaymentAmount);
            currentDiceValue = 7;
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthIsBelowMaximumPaymentDecreasesPlayerBalanceByPercentage()
        {
            horse = new Player("Horse", 1800);
            incomeTax.LandedOnByPlayer(horse, currentDiceValue);

            Assert.AreEqual(1800 - (1800 / ClassicBoard.IncomeTaxPercentage), horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthIsAboveMaximumPaymentDecreasesPlayerBalanceByMaximumPayment()
        {
            horse = new Player("Horse", 2200);
            incomeTax.LandedOnByPlayer(horse, currentDiceValue);

            Assert.AreEqual(2200 - ClassicBoard.MaximumIncomeTaxPaymentAmount, horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWheNetWorthIsZeroDecreasesPlayerBalanceByZero()
        {
            horse = new Player("Horse", 0);
            incomeTax.LandedOnByPlayer(horse, currentDiceValue);

            Assert.AreEqual(0, horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthEqualsMaximumPaymentDecreasesPlayerBonusByMaxiumumPayment()
        {
            horse = new Player("Horse", 2000);
            incomeTax.LandedOnByPlayer(horse, currentDiceValue);

            Assert.AreEqual(2000 - ClassicBoard.MaximumIncomeTaxPaymentAmount, horse.Balance);
        }

        [TestMethod]
        public void PlayerPassingIncomeTaxDoesNotAffectPlayerBalance()
        {
            horse = new Player("Horse", 500);
            incomeTax.PassedByPlayer(horse, currentDiceValue);

            Assert.AreEqual(500, horse.Balance);
        }
    }
}
