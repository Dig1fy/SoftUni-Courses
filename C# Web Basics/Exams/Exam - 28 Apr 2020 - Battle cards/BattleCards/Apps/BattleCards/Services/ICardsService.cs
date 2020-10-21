using BattleCards.ViewModels.Cards;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        IEnumerable<CardViewModel> GetAll();

        int AddCard(AddCardInputModel inputModel); //returns the id of the new card

        void AddToCollection(string userId, int cardId);
    }
}