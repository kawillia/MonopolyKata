using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Strategies;

namespace Monopoly.Board.Locations.Properties
{
    public class PropertyGroup : BoardComponent
    {
        private IEnumerable<Property> Properties { get; set; }
        private Property CurrentPlayerLocation { get; set; }
        private IChargeRentStrategy ChargeRentStrategy { get; set; }

        public override Int32 NumberOfComponents
        {
            get { return Properties.Count(); }
        }

        public PropertyGroup(IChargeRentStrategy chargeRentStrategy, params Property[] properties)
        {
            ChargeRentStrategy = chargeRentStrategy;
            Properties = properties;
        }

        public override Boolean ContainsComponentIndex(Int32 index)
        {
            return Properties.Any(l => l.LocationIndex == index);
        }

        public override void LandedOnByPlayer(Player player, Int32 currentDiceValue)
        {
            CurrentPlayerLocation = Properties.FirstOrDefault(p => p.LocationIndex == player.CurrentLocation);

            if (ShouldBuyProperty(player))
                BuyProperty(player);
            else if (ShouldPayRent(player))
                PayRent(player, currentDiceValue);
        }

        private Boolean ShouldBuyProperty(Player player)
        {
            return !CurrentPlayerLocation.IsOwned && player.BuyingStrategy.ShouldBuy();
        }

        private Boolean ShouldPayRent(Player player)
        {
            return CurrentPlayerLocation.IsOwned && player != CurrentPlayerLocation.Owner;
        }

        private void BuyProperty(Player player)
        {
            player.Balance -= CurrentPlayerLocation.Price;
            CurrentPlayerLocation.Owner = player;
        }

        private void PayRent(Player player, Int32 currentDiceValue)
        {
            Int32 rentAmount = ChargeRentStrategy.CalculateRent(CurrentPlayerLocation, Properties, currentDiceValue);

            player.Balance -= rentAmount;
            CurrentPlayerLocation.Owner.Balance += rentAmount;
        }
    }
}
