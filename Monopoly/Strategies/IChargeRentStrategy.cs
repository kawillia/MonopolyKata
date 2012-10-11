using System;
using System.Collections.Generic;
using Monopoly.Board.Locations.Properties;

namespace Monopoly.Strategies
{
    public interface IChargeRentStrategy
    {
        Int32 CalculateRent(Property propertyLandedOn, IEnumerable<Property> locationsInGroup, Int32 currentDiceValue);
    }
}
