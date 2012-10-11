using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public class Dice
    {
        public const int MinValue = 2;
        public const int MaxValue = 12;

        private const int LowestPossibleDieValue = 1;
        private const int HighestPossibleDieValue = 6;

        Random randomDieValueGenerator;

        public Dice()
        {
            this.randomDieValueGenerator = new Random(LowestPossibleDieValue);
        }

        public int Roll()
        {
            return this.randomDieValueGenerator.Next(LowestPossibleDieValue, HighestPossibleDieValue) + 
                   this.randomDieValueGenerator.Next(LowestPossibleDieValue, HighestPossibleDieValue);
        }
    }
}
