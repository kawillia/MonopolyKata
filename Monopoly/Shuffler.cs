using System;
using System.Collections.Generic;

namespace Monopoly
{
    public class Shuffler<T>
    {
        private Random randomIndexGenerator;
        private List<T> nonShuffledList;
        private List<T> shuffledList;

        public Shuffler()
        {
            this.randomIndexGenerator = new Random();
        }

        public IEnumerable<T> Shuffle(IEnumerable<T> nonShuffledList)
        {
            this.nonShuffledList = new List<T>(nonShuffledList);
            this.shuffledList = new List<T>();

            while (ItemLeftToShuffle())
                ShuffleNextItem();

            return this.shuffledList;
        }

        private Boolean ItemLeftToShuffle()
        {
            return this.nonShuffledList.Count > 0;
        }

        private void ShuffleNextItem()
        {
            Int32 itemIndexToShuffle = this.randomIndexGenerator.Next(0, this.nonShuffledList.Count);
            this.shuffledList.Add(this.nonShuffledList[itemIndexToShuffle]);
            this.nonShuffledList.RemoveAt(itemIndexToShuffle);
        }   
    }
}
