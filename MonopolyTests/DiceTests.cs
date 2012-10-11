using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using MonopolyTests.Fakes;

namespace MonopolyTests
{
    [TestClass]
    public class DiceTests
    {
        private Dice dice;
        private const Int32 NumberOfPossibleRolledValues = 11;

        [TestInitialize]
        public void Initialize()
        {
            this.dice = new Dice();
        }

        [TestMethod]
        public void RollReturnsValueWithinValidRange()
        {
            for (Int32 i = 0; i < 100; i++)
            {
                Int32 diceValue = this.dice.Roll();

                Assert.IsTrue(diceValue >= Dice.MinValue && diceValue <= Dice.MaxValue);
            }
        }

        [TestMethod]
        public void UpperAndLowerDieValuesAreRolled()
        {
            IList<Int32> rolledValues = new List<Int32>();

            for (Int32 i = 0; i < 100; i++)
            {
                rolledValues.Add(this.dice.Roll());
            }

            Assert.AreEqual(NumberOfPossibleRolledValues, rolledValues.Distinct().Count());
        }
    }
}
