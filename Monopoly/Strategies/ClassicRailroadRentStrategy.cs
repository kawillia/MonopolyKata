using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Board;
using Monopoly.Board.Locations.Properties;

namespace Monopoly.Strategies
{
    public class ClassicRailroadRentStrategy : IChargeRentStrategy
    {
        public Int32 CalculateRent(Property railroadLandedOn, IEnumerable<Property> railroadsInGroup, Int32 currentDiceValue)
        {
            Int32 numberOwned = GetNumberOfRailroadOwned(railroadLandedOn, railroadsInGroup);
            return (Int32)Math.Pow(2, numberOwned - 1) * railroadLandedOn.BaseRent;
        }

        private static int GetNumberOfRailroadOwned(Property railroadLandedOn, IEnumerable<Property> railroadsInGroup)
        {
            return railroadsInGroup.Count(l => l.IsOwned && l.Owner == railroadLandedOn.Owner);
        }
    }
}
