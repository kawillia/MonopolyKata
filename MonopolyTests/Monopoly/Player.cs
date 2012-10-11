using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.Players
{
    public class Player
    {
        //private static readonly string[] ValidPieceNames = new string[] { "Horse", "Car" };
        private int currentLocation;
        private string name;

        public int CurrentLocation
        {
            get { return this.currentLocation; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public Player(string name)
        {
            //if (!ValidPieceNames.Contains(name))
            //    throw new ArgumentException("name", "The name specified is not a valid player name.");

            this.name = name;
        }

        public void Move(int numberOfLocations)
        {
            if (numberOfLocations < Dice.MinValue || numberOfLocations > Dice.MaxValue)
                throw new ArgumentOutOfRangeException("numberOfLocations");

            this.currentLocation += numberOfLocations;

            if (this.currentLocation > Game.MaximumLocationIndex)
                this.currentLocation -= Game.NumberOfLocations;
        }
    }
}
