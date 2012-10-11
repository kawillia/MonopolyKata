using System;

namespace Monopoly.Strategies
{
    public class AlwaysBuyStrategy : IBuyingStrategy
    {
        public Boolean ShouldBuy()
        {
            return true;
        }
    }
}
