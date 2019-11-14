﻿namespace MilitaryElite_SecondTry.Models
{
    using MilitaryElite_SecondTry.Contracts;

    public class Repair : IRepair
    {
        public Repair(string partName, int hours)
        {
            this.Part = partName;
            this.Hours = hours;
        }

        public string Part { get; private set; }

        public int Hours { get; private set; }

        public override string ToString()
        {
            return $"  Part Name: {Part} Hours Worked: {Hours}";
        }
    }
}
