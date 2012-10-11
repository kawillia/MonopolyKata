using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Board.Locations.Properties;

namespace Monopoly.Strategies
{
    public class ClassicPropertyRentStrategy : IChargeRentStrategy
    {
        public Int32 CalculateRent(Property propertyLandedOn, IEnumerable<Property> propertiesInGroup, Int32 currentDiceValue)
        {
            if (AllPropertiesAreOwnedBySamePlayer(propertiesInGroup))
                return propertyLandedOn.BaseRent * 2;

            return propertyLandedOn.BaseRent;
        }

        private static Boolean AllPropertiesAreOwnedBySamePlayer(IEnumerable<Property> propertiesInGroup)
        {
            return propertiesInGroup.All(l => l.IsOwned) &&
                   propertiesInGroup.Select(l => l.Owner).Distinct().Count() == 1;
        }
    }
}
