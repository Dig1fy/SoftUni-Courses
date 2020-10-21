using BattleCards.ViewModels.Cards;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        IEnumerable<CardViewModel> GetAll();
    }
}