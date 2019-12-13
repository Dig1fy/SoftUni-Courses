namespace AnimalCentre.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class Play : Procedure
    {
        private const int ENERGY = 6;
        private const int HAPPINESS = 12;
        public override void DoService(IAnimal animal, int procedure)
        {
            base.CheckTime(procedure, animal);
            animal.Energy -= ENERGY;
            animal.Happiness += HAPPINESS;
            base.procedureHistory.Add(animal);
        }
    }
}
