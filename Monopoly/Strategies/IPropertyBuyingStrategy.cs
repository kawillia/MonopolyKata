using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.Strategies
{
    public interface IBuyingStrategy
    {
        Boolean ShouldBuy();
    }
}
