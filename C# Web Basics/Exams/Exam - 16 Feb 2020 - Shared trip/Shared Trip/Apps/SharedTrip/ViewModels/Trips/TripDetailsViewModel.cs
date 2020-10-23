using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class TripDetailsViewModel: TripViewModel
    {
        public string Description { get; set; }

        public string DepartureTimeFormatted => this.DepartureTime.ToString("s");
    }
}
