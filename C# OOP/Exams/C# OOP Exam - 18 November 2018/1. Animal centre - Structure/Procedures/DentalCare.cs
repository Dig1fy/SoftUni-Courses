namespace AnimalCentre.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class DentalCare : Procedure
    {
        private const int HAPPINESS = 12;
        private const int ENERGY = 10;
        public override void DoService(IAnimal animal, int procedure)
        {
            base.CheckTime(procedure, animal);
            animal.Happiness += HAPPINESS;
            animal.Energy += ENERGY;
            base.procedureHistory.Add(animal);
        }
    }
}
