namespace Threeuple
{
    class Tuple<T,K,M>
    {
        private T item1;
        private K item2;
        private M item3;

        public Tuple(T item1, K item2, M item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}
