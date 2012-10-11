using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board.Locations.Properties;
using Monopoly.Classic;
using Monopoly.Strategies;

namespace MonopolyTests.Board
{
    [TestClass]
    public class PropertyTests
    {
        private Player horse;
        private Player hat;
        private Property mediterraneanAvenue;
        private Property balticAvenue;
        private PropertyGroup purpleGroup;
        private Int32 currentDiceValue;

        public PropertyTests()
        {
            horse = new Player("Horse", 2000);
            hat = new Player("Hat", 1500);
            mediterraneanAvenue = new Property(ClassicBoard.MediterraneanAvenueLocation, ClassicBoard.MediterraneanAvenuePrice, ClassicBoard.MediterraneanAvenueRent);
            balticAvenue = new Property(ClassicBoard.BalticAvenueLocation, ClassicBoard.BalticAvenuePrice, ClassicBoard.BalticAvenueRent);
            purpleGroup = new PropertyGroup(new ClassicPropertyRentStrategy(), mediterraneanAvenue, balticAvenue);            
            currentDiceValue = 7;
        }

        [TestMethod]
        public void PlayerLandingOnUnownedPropertyBuysPropertysAndBalanceDecreasesByPrice()
        {
            Player propertyOwnerBeforePurchase = balticAvenue.Owner;
            Int32 balanceBeforePurchase = horse.Balance;

            horse.CurrentLocation = ClassicBoard.BalticAvenueLocation;
            purpleGroup.LandedOnByPlayer(horse, currentDiceValue);

            Assert.AreEqual(null, propertyOwnerBeforePurchase);
            Assert.AreEqual(horse, balticAvenue.Owner);
            Assert.AreEqual(balanceBeforePurchase - ClassicBoard.BalticAvenuePrice, horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnPersonallyOwnedPropertyNothingHappens()
        {
            Int32 balanceBeforePurchase = horse.Balance;

            balticAvenue.Owner = horse;
            horse.CurrentLocation = ClassicBoard.BalticAvenueLocation;
            purpleGroup.LandedOnByPlayer(horse, currentDiceValue);

            Assert.AreEqual(horse, balticAvenue.Owner);
            Assert.AreEqual(balanceBeforePurchase, horse.Balance);
        }

        [TestMethod]
        public void PlayerPassingOverUnownedPropertyNothingHappens()
        {
            Int32 balanceBeforePurchase = horse.Balance;

            horse.CurrentLocation = ClassicBoard.BalticAvenueLocation;
            purpleGroup.PassedByPlayer(horse, currentDiceValue);

            Assert.AreEqual(null, balticAvenue.Owner);
            Assert.AreEqual(balanceBeforePurchase, horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnOwnedPropertyPlayerPaysStatedRent()
        {
            Int32 horseBalanceBeforeRentPayment = horse.Balance;
            Int32 hatBalanaceBeforeRentPayment = hat.Balance;

            balticAvenue.Owner = hat;
            horse.CurrentLocation = ClassicBoard.BalticAvenueLocation;
            purpleGroup.LandedOnByPlayer(horse, currentDiceValue);

            Assert.AreEqual(hat, balticAvenue.Owner);
            Assert.AreEqual(horseBalanceBeforeRentPayment - ClassicBoard.BalticAvenueRent, horse.Balance);
            Assert.AreEqual(hatBalanaceBeforeRentPayment + ClassicBoard.BalticAvenueRent, hat.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnOwnedPropertyGroupBySameOwnerPlayerPaysStatedRentTimesTwo()
        {
            Int32 horseBalanceBeforeRentPayment = horse.Balance;
            Int32 hatBalanaceBeforeRentPayment = hat.Balance;

            mediterraneanAvenue.Owner = hat;
            balticAvenue.Owner = hat;
            horse.CurrentLocation = ClassicBoard.BalticAvenueLocation;
            purpleGroup.LandedOnByPlayer(horse, currentDiceValue);

            Assert.AreEqual(hat, balticAvenue.Owner);
            Assert.AreEqual(horseBalanceBeforeRentPayment - (ClassicBoard.BalticAvenueRent * 2), horse.Balance);
            Assert.AreEqual(hatBalanaceBeforeRentPayment + (ClassicBoard.BalticAvenueRent * 2), hat.Balance);
        }
    }
}
