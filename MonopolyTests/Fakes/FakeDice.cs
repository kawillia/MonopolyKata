using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeDice : Dice
    {
        private Queue<Int32> dieValues;

        public void SetDieValues(params Int32[] dieValues)
        {
            this.dieValues = new Queue<Int32>(dieValues);
        }

        public override Int32 Roll()
        {
            this.dieValueOne = this.dieValues.Dequeue();
            this.dieValueTwo = this.dieValues.Dequeue();

            if (IsDoubles)
                NumberOfConsecutiveDoubles++;

            return this.CurrentValue;
        }
    }
}
