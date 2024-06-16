using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory
{
    public abstract class CardsFactoryBase
    {
        protected IParentCardField _parentCardField;

        protected NewCardsPool _cardsPool;

        protected abstract ICardsPoolContainer Pool {  get; }

        public CardsFactoryBase(NewCardsPool cardsPool, IParentCardField parentCardField)
        {
            _cardsPool = cardsPool;
            _parentCardField = parentCardField;
        }

        public abstract GameCardController CreateCard(Transform parent);
    }
}