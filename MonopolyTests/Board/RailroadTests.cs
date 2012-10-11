using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board.Locations.Properties;
using Monopoly.Classic;
using Monopoly.Strategies;

namespace MonopolyTests.Board
{
    [TestClass]
    public class RailroadTests
    {
        private Player horse;
        private Player hat;
        private Property readingRailroad;
        private Property pennsylvaniaRailroad;
        private Property boRailroad;
        private Property shortLine;
        private PropertyGroup railroadGroup;
        private int currentDiceValue;

        public RailroadTests()
        {
            this.horse = new Player("Horse", 1500);
            this.hat = new Player("Hat", 1000);
            this.currentDiceValue = 7;

            this.readingRailroad = new Property(ClassicBoard.ReadingRailroadLocation, ClassicBoard.RailroadPrice, ClassicBoard.BaseRailroadRent);
            this.pennsylvaniaRailroad = new Property(ClassicBoard.PennsylvaniaAvenueLocation, ClassicBoard.RailroadPrice, ClassicBoard.BaseRailroadRent);
            this.boRailroad = new Property(ClassicBoard.BORailroadLocation, ClassicBoard.RailroadPrice, ClassicBoard.BaseRailroadRent);
            this.shortLine = new Property(ClassicBoard.ShortLineLocation, ClassicBoard.RailroadPrice, ClassicBoard.BaseRailroadRent);
            this.railroadGroup = new PropertyGroup(new ClassicRailroadRentStrategy(), this.readingRailroad, this.pennsylvaniaRailroad, this.boRailroad, this.shortLine);
        }

        [TestMethod]
        public void PlayerLandingOnOneOwnedRailroadPlayerPaysRentOfTwentyFiveDollars()
        {
            Int32 horseBalanceBeforeRentPayment = this.horse.Balance;
            Int32 hatBalanceBeforeRentPayment = this.hat.Balance;

            this.readingRailroad.Owner = this.hat;
            this.horse.CurrentLocation = ClassicBoard.ReadingRailroadLocation;
            this.railroadGroup.LandedOnByPlayer(this.horse, this.currentDiceValue);

            Assert.AreEqual(this.hat, this.readingRailroad.Owner);
            Assert.AreEqual(horseBalanceBeforeRentPayment - 25, this.horse.Balance);
            Assert.AreEqual(hatBalanceBeforeRentPayment + 25, this.hat.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnTwoOwnedRailroadsBySameOwnerPlayerPaysRentOfFiftyDollars()
        {
            Int32 horseBalanceBeforeRentPayment = this.horse.Balance;
            Int32 hatBalanceBeforeRentPayment = this.hat.Balance;

            this.readingRailroad.Owner = this.hat;
            this.pennsylvaniaRailroad.Owner = this.hat;
            this.horse.CurrentLocation = ClassicBoard.ReadingRailroadLocation;
            this.railroadGroup.LandedOnByPlayer(this.horse, this.currentDiceValue);

            Assert.AreEqual(this.hat, this.readingRailroad.Owner);
            Assert.AreEqual(horseBalanceBeforeRentPayment - 50, this.horse.Balance);
            Assert.AreEqual(hatBalanceBeforeRentPayment + 50, this.hat.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnThreeOwnedRailroadsBySameOwnerPlayerPaysRentOfOneHundredDollars()
        {
            Int32 horseBalanceBeforeRentPayment = this.horse.Balance;
            Int32 hatBalanceBeforeRentPayment = this.hat.Balance;

            this.readingRailroad.Owner = this.hat;
            this.pennsylvaniaRailroad.Owner = this.hat;
            this.boRailroad.Owner = this.hat;
            this.horse.CurrentLocation = ClassicBoard.ReadingRailroadLocation;
            this.railroadGroup.LandedOnByPlayer(this.horse, this.currentDiceValue);

            Assert.AreEqual(this.hat, this.readingRailroad.Owner);
            Assert.AreEqual(horseBalanceBeforeRentPayment - 100, this.horse.Balance);
            Assert.AreEqual(hatBalanceBeforeRentPayment + 100, this.hat.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnFourOwnedRailroadsBySameOwnerPlayerPaysRentOfTwoHundredDollars()
        {
            Int32 horseBalanceBeforeRentPayment = this.horse.Balance;
            Int32 hatBalanceBeforeRentPayment = this.hat.Balance;

            this.readingRailroad.Owner = this.hat;
            this.pennsylvaniaRailroad.Owner = this.hat;
            this.boRailroad.Owner = this.hat;
            this.shortLine.Owner = this.hat;
            this.horse.CurrentLocation = ClassicBoard.ReadingRailroadLocation;
            this.railroadGroup.LandedOnByPlayer(this.horse, this.currentDiceValue);

            Assert.AreEqual(this.hat, this.readingRailroad.Owner);
            Assert.AreEqual(horseBalanceBeforeRentPayment - 200, this.horse.Balance);
            Assert.AreEqual(hatBalanceBeforeRentPayment + 200, this.hat.Balance);
        }
    }
}
