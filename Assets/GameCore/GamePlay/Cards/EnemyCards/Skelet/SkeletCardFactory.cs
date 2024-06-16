using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.EnemyCards.Skelet
{
    public class SkeletCardFactory : CardsFactoryBase
    {
        //Temporary constanta
        private const int HEALTH = 2;

        public SkeletCardFactory(CardsPool cardsPool, IParentCardField parentCardField) : base(cardsPool, parentCardField)
        {
        }

        public override GameCardController CreateCard(Transform parent)
        {
            var type = typeof(SkeletCardController);

            GameCardView gameCardView = _cardsPool.CollectCard(type, parent);
            gameCardView.OnKill += () => _cardsPool.Release(type, gameCardView);

            return new SkeletCardController(HEALTH, _parentCardField, gameCardView);
        }
    }

    public class SkeletCardPoolContainer : DefaultCardsPoolContainer
    {
        protected override GameObject _prefab => CardsDatabase.Instance.SkeletCard;
    }
}