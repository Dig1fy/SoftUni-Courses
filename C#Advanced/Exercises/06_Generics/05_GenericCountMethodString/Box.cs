namespace GenericCountMethod
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Box<T>
         where T : IComparable<T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }
        public void Add(T value)
        {
            list.Add(value);
        }

        public int Check(T value)
        {
            var counter = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(value) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
