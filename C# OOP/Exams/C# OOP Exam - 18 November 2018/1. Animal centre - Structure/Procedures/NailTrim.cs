namespace AnimalCentre.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class NailTrim : Procedure
    {
        private const int HAPPINESS = 7;
        public override void DoService(IAnimal animal, int procedure)
        {
            base.CheckTime(procedure, animal);
            animal.Happiness -= HAPPINESS;
            base.procedureHistory.Add(animal);
        }
    }
}
