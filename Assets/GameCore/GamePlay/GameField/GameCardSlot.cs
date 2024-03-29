using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.Utilities.Objects;
using UnityEngine;

namespace Assets.GameCore.GamePlay
{
    public interface IParentCardSlot
    {

    }

    public class GameCardSlot : CachedMonoBehaviour, IParentCardSlot
    {
        private GameCardBase _gameCard;
        public GameCardBase GameCard => _gameCard;

        public void RemoveCard()
        {
            _gameCard = null;
        }

        public void SetCard(GameCardBase card)
        {
            _gameCard = card;
        }
    }
    //temporaty Class
    public class GameCardBase : CachedMonoBehaviour
    {

    }
}