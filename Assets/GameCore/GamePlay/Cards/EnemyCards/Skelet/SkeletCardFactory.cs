using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.EnemyCards.Skelet
{
    public class SkeletCardFactory : CardsFactoryBase
    {
        public SkeletCardFactory(IParentCardField parentCardField) : base(parentCardField)
        {
        }

        protected override CardData _cardData => _database.SkeletCard;

        public override GameCardController CreateCard(Transform parent)
        {
            GameCardView gameCardView = _pool.CollectCard(parent);
            gameCardView.OnKill += () => _pool.ReleaseCard(gameCardView);

            return new SkeletCardController(_cardData, _parentCardField, gameCardView);
        }
    }
}