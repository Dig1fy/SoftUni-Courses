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

        //This is where we connect users and trip in our db
        public void AddUserToTrip(string tripId, string userId)
        {
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public string CreateTrip(TripViewModel inputModel)
        {
            var trip = new Trip
            {
                StartPoint = inputModel.StartPoint,
                EndPoint = inputModel.EndPoint,
                DepartureTime = inputModel.DepartureTime,
                ImagePath = inputModel.ImagePath,
                Seats = inputModel.Seats,
                Description = inputModel.Description
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
            return trip.Id;
        }



        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new HomePageProblemViewModel
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime,
                Seats = x.Seats
            }).ToList();

            return trips;
        }

        public TripViewModel GetTripById(string id)
        {
            var trip = this.db.Trips.Where(x => x.Id == id)
                .Select(y => new TripViewModel
                {                  
                    Id = y.Id,
                    StartPoint = y.StartPoint,
                    EndPoint = y.EndPoint,
                    DepartureTime = y.DepartureTime,
                    //DateTime.ParseExact(y.DepartureTime.ToShortDateString(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Description = y.Description,
                    ImagePath = y.ImagePath,
                    Seats = y.Seats
                }).FirstOrDefault();

            return trip;
        }
    }
}
