namespace AnimalCentre.Procedures
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Procedure : IProcedure
    {
        protected ICollection<IAnimal> procedureHistory;

        protected Procedure()
        {
            procedureHistory = new List<IAnimal>();
        }

        public abstract void DoService(IAnimal animal, int procedure);

        
        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");

            var animalsHistory = procedureHistory
                .OrderBy(x => x.Name)
                .Select(x => x.ToString())
                .ToArray();

            sb.AppendLine(string.Join(Environment.NewLine, animalsHistory));

            return sb.ToString().TrimEnd() ;
        }

        protected void CheckTime(int time, IAnimal animal)
        {
            if (time <= animal.ProcedureTime)
            {
                animal.ProcedureTime -= time;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }
    }
}
