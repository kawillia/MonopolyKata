using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly;

namespace Monopoly.Board
{
    public abstract class BoardComponent
    {
        public abstract Boolean ContainsComponentIndex(Int32 index);
        public virtual void LandedOnByPlayer(Player player, Int32 currentDiceValue) { }
        public virtual void PassedByPlayer(Player player, Int32 currentDiceValue) { }
        public abstract Int32 NumberOfComponents { get; }
    }
}
