namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : ICardRepository
    {
        private List<ICard> listOfCards;

        public CardRepository()
        {
            this.listOfCards = new List<ICard>();
        }
        public int Count
            => this.listOfCards.Count;

        public IReadOnlyCollection<ICard> Cards
            => this.listOfCards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card is null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            if (this.listOfCards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.listOfCards.Add(card);
        }

        public ICard Find(string name)
        => this.listOfCards.Find(x => x.Name == name);

        public bool Remove(ICard card)
        {
            if (card is null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            return this.listOfCards.Remove(card);
        }
    }
}
