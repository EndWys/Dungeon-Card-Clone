using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.Utilities.Objects;
using UnityEngine;

namespace Assets.GameCore.GamePlay
{
    public class GameCardSlot : CachedMonoBehaviour
    {
        [SerializeField] private OneGameCard _gameCard;
        public OneGameCard GameCard => _gameCard;

        public void RemoveCard()
        {
            _gameCard = null;
        }

        public void SetCard(OneGameCard card)
        {
            _gameCard = card;
        }
    }
}