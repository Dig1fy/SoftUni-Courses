using BattleCards.Data;
using BattleCards.ViewModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(AddCardInputModel inputModel)
        {
            var card = new Card
            {
                Attack = inputModel.Attack,
                Description = inputModel.Description,
                Health = inputModel.Health,
                ImageUrl = inputModel.Image,
                Keyword = inputModel.Keyword,
                Name = inputModel.Name,
            };

            this.db.Cards.Add(card);
            this.db.SaveChanges();
            return card.Id;
        }

        public void AddToCollection(string userId, int cardId)
        {
            if (this.db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            var uc = new UserCard
            {
                UserId = userId,
                CardId = cardId
            };

            this.db.UserCards.Add(uc);
            this.db.SaveChanges();
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            var cards = this.db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
                Attack = x.Attack,
                Description = x.Description,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Type = x.Keyword
            }).ToArray();

            return cards;
        }

        public IEnumerable<CardViewModel> GetCollectionByUserId(string userId)
        {
            var cards = this.db.UserCards.Where(x => x.UserId == userId)
                .Select(y => new CardViewModel
                {
                    Attack = y.Card.Attack,
                    Description = y.Card.Description,
                    Health = y.Card.Health,
                    Id = y.CardId,
                    ImageUrl = y.Card.ImageUrl,
                    Name = y.Card.Name,
                    Type = y.Card.Keyword
                }).ToList();

            return cards;
        }

        public void RemoveCardFromCollection(int cardId, string userId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);

            if (userCard == null)
            {
                return;
            }

            this.db.UserCards.Remove(userCard);
            this.db.SaveChanges();
        }
    }
}
