using SharedTrip.ViewModels.Home;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        IEnumerable<TripViewModel> GetAll();

        //returns the id of the new trip so we can use it in AddTripToUser(tripId, userId)
        string CreateTrip(AddTripInputModel inputModel);

        void AddUserToTrip(string tripId, string userId);

        TripDetailsViewModel GetTripById(string tripId);

        bool HasAvailableSeats(string tripId);

        bool IsUserAlreadyInThisTrip(string userId, string tripId);
    }
}
