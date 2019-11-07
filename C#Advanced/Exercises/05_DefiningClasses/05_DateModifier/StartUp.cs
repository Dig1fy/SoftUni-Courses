namespace DateModifier
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var startDate = Console.ReadLine();
            var endDate = Console.ReadLine();

            var modifier = new DateModifier();
            var result = modifier.GetDaysDifferenceBetweenTwoDates(startDate, endDate);

            Console.WriteLine(result);
        }
    }
}
