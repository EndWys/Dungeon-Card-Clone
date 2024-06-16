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

        public SkeletCardFactory(NewCardsPool cardsPool, IParentCardField parentCardField) : base(cardsPool, parentCardField)
        {
        }

        protected override ICardsPoolContainer Pool => _cardsPool.SkeletCardPoolContainer;

        public override GameCardController CreateCard(Transform parent)
        {
            GameCardView gameCardView = Pool.CollectCard(parent);
            gameCardView.OnKill += () => Pool.ReleaseCard(gameCardView);

            return new SkeletCardController(HEALTH, _parentCardField, gameCardView);
        }
    }
}