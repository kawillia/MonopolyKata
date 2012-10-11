using System;

namespace Monopoly
{
    public class Dice
    {
        public const Int32 MinValue = 2;
        public const Int32 MaxValue = 12;

        public Int32 CurrentValue 
        {
            get { return dieValueOne + dieValueTwo; } 
        }

        public Boolean IsDoubles 
        {
            get { return (dieValueOne == dieValueTwo); } 
        }

        public Int32 NumberOfConsecutiveDoubles { get; protected set; }

        private static Random randomDieValueGenerator = new Random(LowestPossibleDieValue);

        private const Int32 LowestPossibleDieValue = 1;
        private const Int32 HighestPossibleDieValue = 6;

        protected Int32 dieValueOne;
        protected Int32 dieValueTwo;

        public virtual Int32 Roll()
        {
            dieValueOne = randomDieValueGenerator.Next(LowestPossibleDieValue, HighestPossibleDieValue + 1);
            dieValueTwo = randomDieValueGenerator.Next(LowestPossibleDieValue, HighestPossibleDieValue + 1);

            if (IsDoubles)
                NumberOfConsecutiveDoubles++;

            return CurrentValue;
        }
    }
}
