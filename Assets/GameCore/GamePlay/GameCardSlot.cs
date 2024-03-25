using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.Utilities.Objects;
using UnityEngine;

namespace Assets.GameCore.GamePlay
{
    public interface IParentCardSlot
    {
        void UnparentCard();
    }

    public class GameCardSlot : CachedMonoBehaviour, IParentCardSlot
    {
        private OneGameCard _gameCard;
        public OneGameCard GameCard => _gameCard;

        public void RemoveCard()
        {
            _gameCard = null;
        }

        public void SetCard(OneGameCard card)
        {
            _gameCard = card;
        }

        public void UnparentCard()
        {
            RemoveCard();
        }
    }
}