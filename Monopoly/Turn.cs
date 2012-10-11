using System;
using Monopoly.Board;

namespace Monopoly
{
    public class Turn
    {
        public Int32 NumberOfLocationsLandedOn { get; private set; }

        private Dice Dice { get; set; }
        private Player Player { get; set; }
        private GameBoard Board { get; set; }
        private BoardComponent CurrentPlayerLocation { get; set; }

        public Turn(Dice dice, Player player, GameBoard board)
        {
            Dice = dice;
            Player = player;
            Board = board;
        }

        public void Take()
        {
            if (Player.IsInJail && Player.GetOutOfJailStrategy.PayToGetOutOfJail())
                PayToGetOutOfJail();

            if (Player.IsInJail)
                TakeTurnWhileInJail();
            else
                TakeNormalTurn();
        }

        private void TakeTurnWhileInJail()
        {
            Player.NumberOfTurnsInJail++;
            Dice.Roll();

            if (Dice.IsDoubles)
            {
                Player.IsInJail = false;
                Player.NumberOfTurnsInJail = 0;
                MovePlayer();
            }
            else if (Player.NumberOfTurnsInJail == 3)
            {
                PayToGetOutOfJail();
                MovePlayer();
            }
        }

        private void TakeNormalTurn()
        {
            do
            {
                Dice.Roll();

                if (Dice.NumberOfConsecutiveDoubles == 3)
                    MovePlayerToDoublesPenaltyLocation();
                else
                    MovePlayer();
            }
            while (Dice.IsDoubles && Dice.NumberOfConsecutiveDoubles < 3 && !Player.IsInJail);
        }

        private void PayToGetOutOfJail()
        {
            Player.Balance -= 50;
            Player.IsInJail = false;
            Player.NumberOfTurnsInJail = 0;
        }
        
        private void MovePlayerToDoublesPenaltyLocation()
        {
            Player.CurrentLocation = Board.GetDoublesPenaltyLocation();
        }

        private void MovePlayer()
        {
            for (Int32 i = 1; i < Dice.CurrentValue; i++)
                Board.PassNextLocation(Player, Dice.CurrentValue);

            Board.LandOnNextLocation(Player, Dice.CurrentValue);
            NumberOfLocationsLandedOn++;
        }
    }
}
