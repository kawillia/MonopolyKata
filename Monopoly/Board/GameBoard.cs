using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly;
using Monopoly.Board;

namespace Monopoly.Board
{
    public abstract class GameBoard
    {
        protected List<BoardComponent> boardComponents;
        public Int32 TotalNumberOfLocations { get; private set; }
        
        public GameBoard()
        {
            CreateBoardComponents();
            TotalNumberOfLocations = boardComponents.Sum(l => l.NumberOfComponents);
        }

        public abstract Int32 GetDoublesPenaltyLocation();

        protected abstract void CreateBoardComponents();        

        protected BoardComponent GetBoardComponent(Int32 locationIndex)
        {
            return boardComponents.First(bc => bc.ContainsComponentIndex(locationIndex));
        }

        public void PassNextLocation(Player player, int currentDiceValue)
        {
            MovePlayerOneLocation(player);
            GetBoardComponent(player.CurrentLocation).PassedByPlayer(player, currentDiceValue);
        }

        public void LandOnNextLocation(Player player, int currentDiceValue)
        {
            MovePlayerOneLocation(player);
            GetBoardComponent(player.CurrentLocation).LandedOnByPlayer(player, currentDiceValue);
        }

        private void MovePlayerOneLocation(Player player)
        {
            player.CurrentLocation = (player.CurrentLocation + 1) % TotalNumberOfLocations;
        }
    }
}
