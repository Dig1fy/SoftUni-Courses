namespace GenericBoxOfStrings
{
   public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return $"{value.GetType()}: {value}";
        }
    }
}
