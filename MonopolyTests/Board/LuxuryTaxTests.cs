using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board.Locations;
using Monopoly.Classic;

namespace MonopolyTests.Board
{
    [TestClass]
    public class LuxuryTaxTests
    {
        private Player horse;
        private LuxuryTax luxuryTax;
        private Int32 currentDiceValue;

        public LuxuryTaxTests()
        {
            luxuryTax = new LuxuryTax(ClassicBoard.LuxuryTaxLocation, ClassicBoard.LuxuryTaxPaymentAmount);
            currentDiceValue = 7;
        }

        [TestMethod]
        public void PlayerLandingOnLuxuryTaxDecreasesPlayerBalanceByLuxuryTaxAmount()
        {
            horse = new Player("Horse", 1500);
            luxuryTax.LandedOnByPlayer(this.horse, this.currentDiceValue);

            Assert.AreEqual(1500 - ClassicBoard.LuxuryTaxPaymentAmount, this.horse.Balance);
        }
    }
}
