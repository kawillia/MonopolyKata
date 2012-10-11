using System;

namespace Monopoly.Board.Locations
{
    public class Go : Location
    {
        public Int32 GoSalaryBonus { get; private set; }

        public Go(Int32 locationIndex, Int32 goSalaryBonus)
            : base(locationIndex)
        {
            GoSalaryBonus = goSalaryBonus;
        }

        public override void LandedOnByPlayer(Player player, Int32 currentDiceValue)
        {
            ReceiveGoSalaryBonus(player);
        }

        public override void PassedByPlayer(Player player, Int32 currentDiceValue)
        {
            ReceiveGoSalaryBonus(player);
        }

        private void ReceiveGoSalaryBonus(Player player)
        {
            player.Balance += GoSalaryBonus;
        }
    }
}
