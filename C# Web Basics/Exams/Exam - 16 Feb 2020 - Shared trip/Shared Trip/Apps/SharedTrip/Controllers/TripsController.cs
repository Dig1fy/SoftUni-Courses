using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            var viewModel = this.tripsService.GetAll();
            return this.View(viewModel);
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripViewModel inputModel)
        {
            if (string.IsNullOrWhiteSpace(inputModel.StartPoint))
            {
                return this.Error("Startpoint cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(inputModel.EndPoint))
            {
                return this.Error("EndPoint cannot be empty");
            }

            if (inputModel.Seats < 2 || inputModel.Seats > 6)
            {
                return this.Error("Seets should be between 2 and 6");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Description) || inputModel.Description.Length > 80)
            {
                return this.Error("Description should be between 1 and 80 characters long.");
            }

            var tripId = this.tripsService.CreateTrip(inputModel);
            var userId = this.GetUserId();
            this.tripsService.AddUserToTrip(tripId, userId);

            return this.Redirect("/trips/all");
        }

        public HttpResponse Details(string tripId)
        {
            var viewModel = this.tripsService.GetTripById(tripId);
            return this.View(viewModel);
        }


        //TODO FIX THAT SHIT !~
        [HttpPost("/Trips/AddUserToTrip")]
        public HttpResponse Details(string tripId, string x)
        {
            var userId = this.GetUserId();
            this.tripsService.AddUserToTrip(tripId, userId);

            return this.Redirect("/trips/all");
        }
    }
}
