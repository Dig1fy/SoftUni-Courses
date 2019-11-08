namespace ClassBoxData
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        private double Length
        {
            get => this.length; 

            set
            {
                Validate(value, "Length");
                this.length = value;
            }
        }

        private double Width
        {
            get => this.width;

            set
            {
                Validate(value, "Width");
                this.width = value;
            }
        }
        private double Height
        {
            get => this.height;

            set
            {
                Validate(value, "Height");
                this.height = value;
            }
        }

        private static void Validate(double value, string parameter)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{parameter} cannot be zero or negative.");
            }
        }

        public string GetVolume()
        {
            var volume = this.length * this.width * this.height;
            return $"Volume - {volume:F2}";
        }
        public string GetSurfaceArea()
        {
            var area = 2 * this.length * this.width + 2 * this.height*this.length + 2 * this.height * width;
            return $"Surface Area - {area:F2}";
        }

        public string GetLateralSurfaceArea()
        {
            var lateralArea = 2*this.length*height + 2*this.width*this.height;
            return $"Lateral Surface Area - {lateralArea:F2}";
        }
    }
}
