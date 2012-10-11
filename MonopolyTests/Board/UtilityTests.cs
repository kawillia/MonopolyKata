using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using System;
using Monopoly.Board.Locations.Properties;
using Monopoly.Strategies;
using Monopoly.Classic;

namespace MonopolyTests.Board
{
    [TestClass]
    public class UtilityTests
    {
        private Player horse;
        private Player hat;
        private Property electricCompany;
        private Property waterWorks;
        private PropertyGroup utilityGroup;
        private Int32 currentDiceValue;

        public UtilityTests()
        {
            this.horse = new Player("Horse", 1500);
            this.hat = new Player("Hat", 1000);
            this.electricCompany = new Property(ClassicBoard.ElectricCompanyLocation, ClassicBoard.UtilityPrice, 0);
            this.waterWorks = new Property(ClassicBoard.ElectricCompanyLocation, ClassicBoard.UtilityPrice, 0);
            this.utilityGroup = new PropertyGroup(new ClassicUtilityRentStrategy(), this.electricCompany, this.waterWorks);
            this.currentDiceValue = 7;
        }

        [TestMethod]
        public void PlayerLandingOnOneOwnedUtilityPlayerPaysRentOfFourTimesCurrentDiceValue()
        {
            Int32 horseBalanceBeforeRentPayment = this.horse.Balance;
            Int32 hatBalanceBeforeRentPayment = this.hat.Balance;

            this.electricCompany.Owner = this.hat;
            this.horse.CurrentLocation = ClassicBoard.ElectricCompanyLocation;
            this.utilityGroup.LandedOnByPlayer(this.horse, this.currentDiceValue);

            Assert.AreEqual(this.hat, this.electricCompany.Owner);
            Assert.AreEqual(horseBalanceBeforeRentPayment - (4 * this.currentDiceValue), this.horse.Balance);
            Assert.AreEqual(hatBalanceBeforeRentPayment + (4 * this.currentDiceValue), this.hat.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnTwoOwnedUtilitiesPlayerPaysRentOfTenTimesCurrentDiceValue()
        {
            Int32 horseBalanceBeforeRentPayment = this.horse.Balance;
            Int32 hatBalanceBeforeRentPayment = this.hat.Balance;

            this.electricCompany.Owner = this.hat;
            this.waterWorks.Owner = this.hat;
            this.horse.CurrentLocation = ClassicBoard.ElectricCompanyLocation;
            this.utilityGroup.LandedOnByPlayer(this.horse, this.currentDiceValue);

            Assert.AreEqual(this.hat, this.electricCompany.Owner);
            Assert.AreEqual(horseBalanceBeforeRentPayment - (10 * this.currentDiceValue), this.horse.Balance);
            Assert.AreEqual(hatBalanceBeforeRentPayment + (10 * this.currentDiceValue), this.hat.Balance);
        }
    }
}
