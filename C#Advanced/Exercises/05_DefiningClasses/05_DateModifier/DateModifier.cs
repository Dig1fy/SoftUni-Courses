namespace DateModifier
{
    using System;

    public class DateModifier
    {
        public double GetDaysDifferenceBetweenTwoDates (string first, string second)
        {
            DateTime startDate = DateTime.Parse(first);
            DateTime endDate = DateTime.Parse(second);
            var result = Math.Abs((startDate - endDate).TotalDays);

            return result;
        }
    }
}
