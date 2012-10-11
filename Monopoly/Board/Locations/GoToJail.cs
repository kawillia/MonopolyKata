 using System;

namespace Monopoly.Board.Locations
{
    public class GoToJail : Location
    {
        public Int32 LocationToSendPlayerTo { get; private set; }

        public GoToJail(Int32 locationIndex, Int32 locationToSendPlayerTo)
            : base(locationIndex)
        {
            LocationToSendPlayerTo = locationToSendPlayerTo;
        }

        public override void LandedOnByPlayer(Player player, Int32 currentDiceValue)
        {
            player.CurrentLocation = LocationToSendPlayerTo;
            player.IsInJail = true;
        }
    }
}
