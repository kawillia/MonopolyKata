using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly;
using Monopoly.Strategies;

namespace Monopoly
{
    public class Player
    {
        public string Name { get; private set; }
        public Int32 Balance { get; set; }
        public Int32 CurrentLocation { get; set; }
        public Int32 NetWorth { get { return this.Balance; } }
        public Boolean IsInJail { get; set; }
        public Int32 NumberOfTurnsInJail { get; set; }
        public IBuyingStrategy BuyingStrategy { get; set; }
        public IGetOutOfJailStrategy GetOutOfJailStrategy { get; set; }

        public Player(string name)
            : this(name, 0)
        { }

        public Player(string name, Int32 initialBalance)
        {
            Name = name;
            Balance = initialBalance;
            BuyingStrategy = new AlwaysBuyStrategy();
            GetOutOfJailStrategy = new AlwaysPayToGetOutOfJail();
        }
    }
}
