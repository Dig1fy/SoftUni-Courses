using SharedTrip.Data;
using SharedTrip.ViewModels.Home;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService 
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        //public void AddUserToTrip(string tripId, string userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public string CreateTrip(TripViewModel inputModel)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<HomePageProblemViewModel> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public TripViewModel GetTripById(string tripId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
