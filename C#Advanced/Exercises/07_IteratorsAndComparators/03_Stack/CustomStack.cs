namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> data;

        public CustomStack(params T[] data)
            {
            this.data = data.ToList();
            }

        public void Push(params T[] input)
        {
            this.data.AddRange(input);
        }
        
        public T Pop()
        {
            if (this.data.Count<=0)
            {
                throw new ArgumentException("No elements");
            }
            else
            {
                var element = this.data[this.data.Count - 1];
                this.data.Remove(element);
                return element;
            }
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
        
    }
}
