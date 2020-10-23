using SharedTrip.Data;
using SharedTrip.ViewModels.Home;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddUserToTrip(string userId, string tripId)
        {
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public string CreateTrip(AddTripInputModel inputModel)
        {
            var trip = new Trip
            {
                StartPoint = inputModel.StartPoint,
                EndPoint = inputModel.EndPoint,
                Description = inputModel.Description,
                DepartureTime = DateTime.ParseExact(inputModel.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Seats = inputModel.Seats,
                ImagePath = inputModel.ImagePath
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
            return trip.Id;
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new TripViewModel
            {                
                DepartureTime = x.DepartureTime,
                EndPoint = x.EndPoint,
                StartPoint = x.StartPoint,
                Id = x.Id,
                Seats = x.Seats,
                UsedSeats = x.UserTrips.Count(),
            }).ToList();

            return trips;
        }

        public TripDetailsViewModel GetTripById(string tripId)
        {
            return this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new TripDetailsViewModel
                {
                    
                    DepartureTime = x.DepartureTime,
                    Description = x.Description,
                    EndPoint = x.EndPoint,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    StartPoint = x.StartPoint,
                    UsedSeats = x.UserTrips.Count(),
                }).FirstOrDefault();
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new { x.Seats, TakenSeats = x.UserTrips.Count() })
                .FirstOrDefault();

            var availableSeats = trip.Seats - trip.TakenSeats;
            return availableSeats > 0;
        }

        public bool IsUserAlreadyInThisTrip(string userId, string tripId)=>
             this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);
    }
}
