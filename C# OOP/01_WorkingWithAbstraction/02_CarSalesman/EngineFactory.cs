using System;
using System.Collections.Generic;
using System.Text;

namespace CarsSalesman
{
    public class EngineFactory
    {
        public Engine Create(string[] parameters)
        {
            var model = parameters[0];
            var power = int.Parse(parameters[1]);

            if (parameters.Length == 3 && int.TryParse(parameters[2], out int displacement))
            {
                return new Engine(model, power, displacement);
            }
            else if (parameters.Length == 3)
            {
                var efficiency = parameters[2];
                return new Engine(model, power, efficiency);
            }
            else if (parameters.Length == 4)
            {
                var efficiency = parameters[3];
                return new Engine(model, power, int.Parse(parameters[2]), efficiency);
            }
            else
            {
                return new Engine(model, power);
            }
        }
    }
}
