using SharedTrip.ViewModels.Home;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        IEnumerable<HomePageProblemViewModel> GetAll();

        //returns the id of the new trip so we can use it in AddTripToUser(tripId, userId)
        string CreateTrip(TripViewModel inputModel);

        void AddUserToTrip(string tripId, string userId);

        TripViewModel GetTripById(string tripId);
    }
}
