namespace AnimalCentre.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class Vaccinate : Procedure
    {
        private const int ENERGY = 8;
        
        public override void DoService(IAnimal animal, int procedure)
        {
            base.CheckTime(procedure, animal);
            animal.Energy -= ENERGY;
            animal.IsVaccinated = true;
            base.procedureHistory.Add(animal);
        }
    }
}
