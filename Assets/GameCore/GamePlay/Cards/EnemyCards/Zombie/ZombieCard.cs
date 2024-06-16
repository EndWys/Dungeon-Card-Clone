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

        public ZombieCardFactory(CardsPool cardsPool, IParentCardField parentCardField) : base(cardsPool, parentCardField)
        {
        }

        public override GameCardController CreateCard(Transform parent)
        {
            var type = typeof(ZombieCardController);

            GameCardView gameCardView = _cardsPool.CollectCard(type, parent);
            gameCardView.OnKill += () => _cardsPool.Release(type, gameCardView);

            return new ZombieCardController(HEALTH, _parentCardField, gameCardView);
        }
    }

    public class ZombieCardPoolContainer : DefaultCardsPoolContainer
    {
        protected override GameObject _prefab => CardsDatabase.Instance.ZombieCard;
    }
}