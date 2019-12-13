namespace AnimalCentre.Procedures
{
    using System;
    using AnimalCentre.Models.Contracts;

    public class Chip : Procedure
    {
        private const int HAPPINESS = 5;
        public override void DoService(IAnimal animal, int procedure)
        {
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            base.CheckTime(procedure, animal);
            animal.IsChipped = true;
            animal.Happiness -= HAPPINESS;
            base.procedureHistory.Add(animal);
        }
    }
}
