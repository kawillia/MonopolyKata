using System;

namespace Monopoly.Strategies
{
    public class NeverPayToGetOutOfJail : IGetOutOfJailStrategy
    {
        public Boolean PayToGetOutOfJail()
        {
            return false;
        }
    }
}
