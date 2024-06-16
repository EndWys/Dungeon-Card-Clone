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

        public ZombieCardFactory(IParentCardField parentCardField) : base(parentCardField)
        {
        }

        protected override GameObject _cardPrefab => _database.ZombieCard;

        public override GameCardController CreateCard(Transform parent)
        {
            GameCardView gameCardView = _pool.CollectCard(parent);
            gameCardView.OnKill += () => _pool.ReleaseCard(gameCardView);

            return new ZombieCardController(HEALTH, _parentCardField, gameCardView);
        }
    }
}