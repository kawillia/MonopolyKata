using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.Classic
{
    public class ClassicGame : Game
    {
        public ClassicGame()
            : base(new ClassicBoard(), new Dice())
        {
        }
    }
}
