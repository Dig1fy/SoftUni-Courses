namespace Students
{
    class Students
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public Students(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;

            this.LastName = lastName;

            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }
}
