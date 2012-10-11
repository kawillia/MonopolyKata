using System;
using Monopoly.Strategies;

namespace MonopolyTests
{
    public class NeverBuyStrategy : IBuyingStrategy
    {
        public Boolean ShouldBuy()
        {
            return false;
        }
    }
}
