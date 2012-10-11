using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Players;

namespace MonopolyTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerMoveUpdatesPlayerPosition()
        {
            Player horsePlayer = new Player("Horse");
            horsePlayer.Move(7);

            Assert.AreEqual(7, horsePlayer.CurrentLocation);
        }

        [TestMethod]
        public void PlayerMoveOverMaxLocationsRollsOver()
        {
            Player horsePlayer = new Player("Horse");
            horsePlayer.Move(12);
            horsePlayer.Move(12);
            horsePlayer.Move(12);
            horsePlayer.Move(3);
            horsePlayer.Move(6);

            Assert.AreEqual(5, horsePlayer.CurrentLocation);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayerMoveDoesNotAllowValueBelowTwo()
        {
            Player horsePlayer = new Player("Horse");
            horsePlayer.Move(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayerMoveDoesNotAllowValueAboveTwelve()
        {
            Player horsePlayer = new Player("Horse");
            horsePlayer.Move(13);
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void CreatePlayerWithInvalidNameThrowsException()
        //{
        //    Player invalidPlayer = new Player("Invalid");
        //}
    }
}
