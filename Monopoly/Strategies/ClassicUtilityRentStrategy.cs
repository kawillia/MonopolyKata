using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Board.Locations.Properties;

namespace Monopoly.Strategies
{
    public class ClassicUtilityRentStrategy : IChargeRentStrategy
    {
        public Int32 CalculateRent(Property propertyLandedOn, IEnumerable<Property> utilitiesInGroup, Int32 currentDiceValue)
        {
            if (AllUtilitiesAreOwned(utilitiesInGroup))
                return currentDiceValue * 10;

            return currentDiceValue * 4;
        }

        private static Boolean AllUtilitiesAreOwned(IEnumerable<Property> utilitiesInGroup)
        {
            return utilitiesInGroup.All(u => u.IsOwned);
        }
    }
}
