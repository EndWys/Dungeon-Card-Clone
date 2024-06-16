using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory
{
    public abstract class CardsFactoryBase
    {
        private DefaultCardsPoolContainer _cardsPoolContainer = new DefaultCardsPoolContainer();

        protected IParentCardField _parentCardField;
        protected CardsDatabase _database => CardsDatabase.Instance;
        protected ICardsPoolContainer _pool => _cardsPoolContainer;
        protected abstract GameObject _cardPrefab { get; }

        public CardsFactoryBase(IParentCardField parentCardField)
        {
            _parentCardField = parentCardField;
            _cardsPoolContainer.Initialize(_cardPrefab);
        }

        public abstract GameCardController CreateCard(Transform parent);
    }
}