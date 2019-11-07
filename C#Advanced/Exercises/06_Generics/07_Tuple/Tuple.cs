namespace Tuple
{
    class Tuple<T,K>
    {
        private T item1;
        private K item2;

        public Tuple(T item1, K item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
