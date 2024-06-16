using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.EnemyCards.Zombie
{
    public class ZombieCardController : BaseEnemyCardController
    {
        public ZombieCardController(int health, IParentCardField parentCardField, GameCardView gameCardView) : base(health, parentCardField, gameCardView)
        {

        }
    }

    public class ZombieCardFactory : CardsFactoryBase
    {
        //Temporary constanta
        private const int HEALTH = 2;

        public ZombieCardFactory(NewCardsPool cardsPool, IParentCardField parentCardField) : base(cardsPool, parentCardField)
        {
        }
        protected override ICardsPoolContainer Pool => _cardsPool.ZombieCardPoolContainer;

        public override GameCardController CreateCard(Transform parent)
        {
            GameCardView gameCardView = Pool.CollectCard(parent);
            gameCardView.OnKill += () => Pool.ReleaseCard(gameCardView);

            return new ZombieCardController(HEALTH, _parentCardField, gameCardView);
        }
    }
}