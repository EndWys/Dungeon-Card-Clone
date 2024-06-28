using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.GameField;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.EnemyCards.Zombie
{
    public class ZombieCardController : BaseEnemyCardController
    {
        public ZombieCardController(CardData cardData, IParentCardField parentCardField, GameCardView gameCardView) : base(cardData, parentCardField, gameCardView)
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

        protected override CardData _cardData => _database.ZombieCard;

        public override GameCardController CreateCard(Transform parent)
        {
            GameCardView gameCardView = _pool.CollectCard(parent);
            gameCardView.OnKill += () => _pool.ReleaseCard(gameCardView);

            return new ZombieCardController(_cardData, _parentCardField, gameCardView);
        }
    }
}