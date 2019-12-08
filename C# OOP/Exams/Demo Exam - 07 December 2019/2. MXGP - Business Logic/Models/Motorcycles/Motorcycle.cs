namespace MXGP.Models.Motorcycles
{
    using MXGP.Models.Motorcycles.Contracts;
    using System;

    public abstract class Motorcycle : IMotorcycle
    {
        public Motorcycle(string model
            , int horsePower
            , double cubicCentimeters
            , int minHorsePower
            , int maxHorsePower)
        {
            if (string.IsNullOrWhiteSpace(model) || model.Length < 4)
            {
                throw new ArgumentException($"Model {model} cannot be less than 4 symbols.");
            }
            if (horsePower < minHorsePower || horsePower > maxHorsePower)
            {
                throw new ArgumentException($"Invalid horse power: {horsePower}.");
            }

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model { get; }
        public int HorsePower { get; }
        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}