namespace ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator(List<T> elements)
        {
            this.list = new List<T>(elements);
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (index + 1 < this.list.Count)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (!list.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");                
            }

            Console.WriteLine(list[index]);
        }
    }
}
