using BattleCards.Services;
using BattleCards.ViewModels.Cards;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse All()
        {
            var viewModel = this.cardsService.GetAll();
            return this.View(viewModel);
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel inputModel)
        {

            if (string.IsNullOrEmpty(inputModel.Name) || inputModel.Name.Length < 5 || inputModel.Name.Length > 15)
            {
                return this.Error("Name should be between 5 and 15 characters long.");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Image))
            {
                return this.Error("The image is required!");
            }

            if (!Uri.TryCreate(inputModel.Image, UriKind.Absolute, out _))
            {
                return this.Error("Invalid image url.");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Keyword))
            {
                return this.Error("Keyword is required.");
            }

            if (inputModel.Attack < 0)
            {
                return this.Error("Attack should be non-negative integer.");
            }

            if (inputModel.Health < 0)
            {
                return this.Error("Health should be non-negative integer.");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Description) || inputModel.Description.Length > 200)
            {
                return this.Error("Description should be between 1 and 200 characters long.");
            }

            var cardId = this.cardsService.AddCard(inputModel);
            var userId = this.GetUserId();

            this.cardsService.AddToCollection(userId, cardId);
            return this.View("/Cards/All");
        }
    }
}
