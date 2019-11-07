namespace GenericSwapMethodIntegers
{
    using System.Collections.Generic;
    using System.Text;
    public class Box<T>
    {        
        private List<T> listOfBoxes;
        public Box()
        {
            listOfBoxes = new List<T>();
        }

        public void Add(T value)
        {
            listOfBoxes.Add(value);
        }        

        public List<T> Swap( int firstIndex, int secondIndex)
        {
            bool isInRange = firstIndex >= 0 && firstIndex < listOfBoxes.Count && secondIndex >= 0 && secondIndex < listOfBoxes.Count;

            if (isInRange)
            {
                var temp = listOfBoxes[firstIndex];
                listOfBoxes[firstIndex] = listOfBoxes[secondIndex];
                listOfBoxes[secondIndex] = temp;
            }

            return listOfBoxes;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var item in listOfBoxes)
            {
                builder.AppendLine($"{item.GetType()}: {item}");
            }
            return builder.ToString().TrimEnd();
        }
    }
}
