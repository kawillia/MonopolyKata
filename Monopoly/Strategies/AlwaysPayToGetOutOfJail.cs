using System;

namespace Monopoly.Strategies
{
    public class AlwaysPayToGetOutOfJail : IGetOutOfJailStrategy
    {
        public Boolean PayToGetOutOfJail()
        {
            return true;
        }
    }
}
