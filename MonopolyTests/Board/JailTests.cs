using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board.Locations;
using Monopoly.Classic;
using Monopoly.Strategies;
using MonopolyTests.Fakes;

namespace MonopolyTests.Board
{
    [TestClass]
    public class JailTests
    {
        private Player player;
        private GoToJail goToJail;
        private FakeDice dice;
        private Turn turn;

        public JailTests()
        {
            player = new Player("Name", 1500);
            player.BuyingStrategy = new NeverBuyStrategy();
            goToJail = new GoToJail(ClassicBoard.GoToJailLocation, ClassicBoard.JailLocation);
            dice = new FakeDice();
            turn = new Turn(dice, player, new ClassicBoard());
        }

        [TestMethod]
        public void PlayerLandingOnGoToJailDoesNotChangePlayerBalance()
        {
            player.CurrentLocation = ClassicBoard.GoToJailLocation;
            goToJail.LandedOnByPlayer(player, 5);

            Assert.AreEqual(1500, player.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnGoToJailMovePlayerToJustVisiting()
        {
            goToJail.LandedOnByPlayer(player, 5);

            Assert.AreEqual(ClassicBoard.JustVisitingLocation, player.CurrentLocation);
        }

        [TestMethod]
        public void PlayerPassingGoToJailDoesNotChangeMovePlayerToJustVisiting()
        {            
            goToJail.PassedByPlayer(player, 5);

            Assert.AreEqual(0, player.CurrentLocation);
        }

        [TestMethod]
        public void PlayerPassingGoToJailDoesNotChangePlayerBalance()
        {
            goToJail.PassedByPlayer(player, 5);

            Assert.AreEqual(1500, player.Balance);
        }

        [TestMethod]
        public void RollNonDoublesLandOnGoToJailPlayerIsInJail()
        {
            player.CurrentLocation = 26;
            dice.SetDieValues(1, 3);
            turn.Take();

            Assert.AreEqual(player.CurrentLocation, ClassicBoard.JailLocation);
        }

        [TestMethod]
        public void RollNonDoublesLandOnGoToJailPlayersBalanceIsUnchanged()
        {
            Int32 balanceBefore = player.Balance;
            player.CurrentLocation = 26;
            dice.SetDieValues(1, 3);
            turn.Take();

            Assert.AreEqual(balanceBefore, player.Balance);
        }

        [TestMethod]
        public void RollDoublesLandOnGoToJailPlayerIsInJail()
        {
            player.CurrentLocation = 26;
            dice.SetDieValues(2, 2);
            turn.Take();

            Assert.AreEqual(player.CurrentLocation, ClassicBoard.JailLocation);
        }

        [TestMethod]
        public void RollDoublesLandOnGoToJailPlayersBalanceIsUnchanged()
        {
            Int32 balanceBefore = player.Balance;
            player.CurrentLocation = 26;
            dice.SetDieValues(1, 3);
            turn.Take();

            Assert.AreEqual(balanceBefore, player.Balance);
        }

        [TestMethod]
        public void PassOverGoToJailPlayerIsNotInJail()
        {
            player.CurrentLocation = ClassicBoard.AtlanticAvenueLocation;
            dice.SetDieValues(4, 1);
            turn.Take();

            Assert.AreNotEqual(player.CurrentLocation, ClassicBoard.JailLocation);
            Assert.IsFalse(player.IsInJail);
        }

        [TestMethod]
        public void PassOverGoToJailPlayersBalanceIsUnchanged()
        {
            Int32 balanceBefore = player.Balance;
            player.CurrentLocation = 29;
            dice.SetDieValues(3, 1);
            turn.Take();

            Assert.AreEqual(balanceBefore, player.Balance);
        }

        [TestMethod]
        public void RollDoublesThreeTimesPlayerIsInJail()
        {
            dice.SetDieValues(1, 1, 2, 2, 3, 3);
            turn.Take();

            Assert.AreEqual(ClassicBoard.JailLocation, player.CurrentLocation);
        }

        [TestMethod]
        public void RollDoublesThreeTimesPlayersBalanceIsUnchanged()
        {
            Int32 balanceBefore = player.Balance;
            dice.SetDieValues(1, 1, 2, 2, 3, 3);
            turn.Take();

            Assert.AreEqual(balanceBefore, player.Balance);
        }

        [TestMethod]
        public void RollDoublesThreeTimesPassGoBeforeThirdRollGetGoBonus()
        {
            Int32 balanceBefore = player.Balance;
            player.CurrentLocation = ClassicBoard.BoardwalkLocation;
            dice.SetDieValues(1, 1, 2, 2, 3, 3);
            turn.Take();

            Assert.AreEqual(balanceBefore + ClassicBoard.GoSalaryBonus, player.Balance);
        }

        [TestMethod]
        public void RollDoublesTwoTimesPlayerIsNotInJail()
        {
            dice.SetDieValues(1, 1, 2, 2, 3, 1);
            turn.Take();

            Assert.IsFalse(player.IsInJail);
        }

        [TestMethod]
        public void PlayerPaysFiftyDollarsRollsDoublesPlayerMovesTwice()
        {
            player.CurrentLocation = ClassicBoard.JailLocation;
            player.IsInJail = true;
            dice.SetDieValues(1, 1, 3, 1);
            turn.Take();

            Assert.AreEqual(ClassicBoard.JailLocation + 6, player.CurrentLocation);
        }

        [TestMethod]
        public void PlayerPaysFiftyDollarsRollsDoublesPlayersBalanceDecreasesByFiftyDollars()
        {
            Int32 balanceBefore = player.Balance;
            player.CurrentLocation = ClassicBoard.JailLocation;
            player.IsInJail = true;
            dice.SetDieValues(1, 1, 3, 1);
            turn.Take();

            Assert.AreEqual(balanceBefore - 50, player.Balance);
        }

        [TestMethod]
        public void PlayerDoesNotPayFiftyDollarsRollDoublesPlayerMovesOnce()
        {
            player.GetOutOfJailStrategy = new NeverPayToGetOutOfJail();
            player.CurrentLocation = ClassicBoard.JailLocation;
            player.IsInJail = true;
            dice.SetDieValues(1, 1);
            turn.Take();

            Assert.AreEqual(ClassicBoard.JailLocation + 2, player.CurrentLocation);
        }

        [TestMethod]
        public void PlayerDoesNotPayFiftyDollarsRollDoublesPlayersBalanceIsUnchanged()
        {
            Int32 balanceBefore = player.Balance;
            player.GetOutOfJailStrategy = new NeverPayToGetOutOfJail();
            player.CurrentLocation = ClassicBoard.JailLocation;
            player.IsInJail = true;
            dice.SetDieValues(1, 1);
            turn.Take();

            Assert.AreEqual(balanceBefore, player.Balance);
        }

        [TestMethod]
        public void TurnOneRollDoublesMoveOnce()
        {
            player.GetOutOfJailStrategy = new NeverPayToGetOutOfJail();
            player.CurrentLocation = ClassicBoard.JailLocation;
            player.IsInJail = true;
            dice.SetDieValues(1, 1);
            turn.Take();

            Assert.AreEqual(ClassicBoard.JailLocation + 2, player.CurrentLocation);
            Assert.IsFalse(player.IsInJail);
        }

        [TestMethod]
        public void TurnTwoRollDoublesMoveOnce()
        {
            player.GetOutOfJailStrategy = new NeverPayToGetOutOfJail();
            player.CurrentLocation = ClassicBoard.JailLocation;
            player.IsInJail = true;
            dice.SetDieValues(1, 3);
            turn.Take();

            dice.SetDieValues(1, 1);
            turn.Take();

            Assert.AreEqual(ClassicBoard.JailLocation + 2, player.CurrentLocation);
            Assert.IsFalse(player.IsInJail);
        }

        [TestMethod]
        public void TurnThreeRollDoublesMoveOnce()
        {
            player.GetOutOfJailStrategy = new NeverPayToGetOutOfJail();
            player.CurrentLocation = ClassicBoard.JailLocation;
            player.IsInJail = true;
            dice.SetDieValues(1, 3);
            turn.Take();

            dice.SetDieValues(1, 4);
            turn.Take();

            dice.SetDieValues(1, 1);
            turn.Take();

            Assert.AreEqual(ClassicBoard.JailLocation + 2, player.CurrentLocation);
            Assert.IsFalse(player.IsInJail);
        }

        [TestMethod]
        public void TurnThreeDoNotRollDoublesMoveOnceBalanceDecreasesByFifty()
        {
            Int32 balanceBefore = player.Balance;
            player.GetOutOfJailStrategy = new NeverPayToGetOutOfJail();
            player.CurrentLocation = ClassicBoard.JailLocation;
            player.IsInJail = true;
            dice.SetDieValues(1, 3);
            turn.Take();

            dice.SetDieValues(1, 4);
            turn.Take();

            dice.SetDieValues(1, 5);
            turn.Take();

            Assert.AreEqual(ClassicBoard.JailLocation + 6, player.CurrentLocation);
            Assert.AreEqual(balanceBefore - 50, player.Balance);
            Assert.IsFalse(player.IsInJail);
        }
    }
}
