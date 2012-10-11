using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board;
using Monopoly.Classic;
using MonopolyTests.Fakes;

namespace MonopolyTests
{
    [TestClass]
    public class TurnTests
    {
        private FakeDice fakeDice;
        private Player player;
        private GameBoard board;
        private Turn turn;

        [TestInitialize]
        public void Initialize()
        {
            this.fakeDice = new FakeDice();
            this.player = new Player("Horse");
            this.board = new ClassicBoard();
            this.turn = new Turn(this.fakeDice, this.player, this.board);
        }
        
        [TestMethod]
        public void PlayerPositionWrapsAtEndOfBoard()
        {
            this.player.CurrentLocation = 38;
            this.fakeDice.SetDieValues(1, 6);
            this.turn.Take();

            Assert.AreEqual(5, player.CurrentLocation);
        }

        [TestMethod]
        public void StartOnGoRollDoublesOfSixAndNonDoublesOfFourEndsOnTenLandsOnTwoLocations()
        {
            this.fakeDice.SetDieValues(3, 3, 1, 3);
            this.turn.Take();

            Assert.AreEqual(10, this.player.CurrentLocation);
            Assert.AreEqual(2, this.turn.NumberOfLocationsLandedOn);
        }

        [TestMethod]
        public void PlayerDoesNotRollDoublesMovesRollValuesLandsOnOneLocation()
        {
            this.fakeDice.SetDieValues(3, 1);
            this.turn.Take();

            Assert.AreEqual(4, this.player.CurrentLocation);
            Assert.AreEqual(1, this.turn.NumberOfLocationsLandedOn);
        }

        [TestMethod]
        public void RollDoublesTwiceMovesThreeRollsTotalLandsOnThreeLocations()
        {
            this.fakeDice.SetDieValues(1, 1, 2, 2, 1, 5);
            this.turn.Take();

            Assert.AreEqual(12, this.player.CurrentLocation);
            Assert.AreEqual(3, this.turn.NumberOfLocationsLandedOn);
        }

        [TestMethod]
        public void RollDoublesThreeTimesEndOnJustVisiting()
        {
            this.fakeDice.SetDieValues(1, 1, 2, 2, 3, 3);
            this.turn.Take();

            Assert.AreEqual(ClassicBoard.JustVisitingLocation, this.player.CurrentLocation);
        }
    }
}
