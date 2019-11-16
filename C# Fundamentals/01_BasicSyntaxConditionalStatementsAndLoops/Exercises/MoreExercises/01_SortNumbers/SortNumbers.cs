using System;

namespace SortNumbers
{
    class Program
    {
        static void Main()
        {
            int[] nums = new int[3];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(nums);

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}