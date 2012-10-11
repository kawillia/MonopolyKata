using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class DiceTests
    {
        [TestMethod]
        public void RollReturnsValueWithinValidRange()
        {
            Dice dice = new Dice();
            int diceValue = dice.Roll();

            Assert.IsTrue(diceValue >= Dice.MinValue && diceValue <= Dice.MaxValue);
        }
    }
}
