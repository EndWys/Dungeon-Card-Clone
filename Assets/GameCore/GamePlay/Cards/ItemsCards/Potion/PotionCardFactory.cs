using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.Potion
{
    public class PotionCardFactory : CardsFactoryBase
    {
        public PotionCardFactory(IParentCardField parentCardField) : base(parentCardField)
        {
        }

        protected override CardData _cardData => _database.PotionnCard;

        public override GameCardController CreateCard(Transform parent)
        {
            GameCardView gameCardView = _pool.CollectCard(parent);
            gameCardView.OnKill += () => _pool.ReleaseCard(gameCardView);

            return new PotionCardController(_cardData, _parentCardField, gameCardView);
        }
    }
}