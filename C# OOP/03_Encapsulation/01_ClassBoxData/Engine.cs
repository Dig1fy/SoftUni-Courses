namespace ClassBoxData
{
    using System;

    public class Engine
    {
        public void Run()
        {
            try
            {
                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                var box = new Box(length, width, height);

                PrintResult(box);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintResult(Box box)
        {
            Console.WriteLine(box.GetSurfaceArea());
            Console.WriteLine(box.GetLateralSurfaceArea());
            Console.WriteLine(box.GetVolume());
        }
    }
}
