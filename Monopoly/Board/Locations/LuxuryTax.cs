using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly;

namespace Monopoly.Board.Locations
{
    public class LuxuryTax : Location
    {
        public Int32 TaxAmount { get; private set; }

        public LuxuryTax(Int32 locationIndex, Int32 taxAmount)
            : base(locationIndex)
        {
            TaxAmount = taxAmount;
        }

        public override void LandedOnByPlayer(Player player, Int32 currentDiceValue)
        {
            player.Balance -= TaxAmount;
        }
    }
}
