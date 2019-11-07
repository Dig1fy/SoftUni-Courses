namespace Lake
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Lake : IEnumerable<int>
    {

        private List<int> stones;

        public Lake(params int[] stoneValues)
        {
            this.stones = stoneValues.ToList();
        }


        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return stones[i];
                }

            }

            for (int i = stones.Count - 1; i >= 0; i--)
                if (i % 2 == 1)
                {
                    yield return stones[i];
                }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}
