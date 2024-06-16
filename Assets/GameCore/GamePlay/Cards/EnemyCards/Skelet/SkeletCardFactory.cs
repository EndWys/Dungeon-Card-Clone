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

        public SkeletCardFactory(IParentCardField parentCardField) : base(parentCardField)
        {
        }

        protected override GameObject _cardPrefab => _database.SkeletCard;

        public override GameCardController CreateCard(Transform parent)
        {
            GameCardView gameCardView = _pool.CollectCard(parent);
            gameCardView.OnKill += () => _pool.ReleaseCard(gameCardView);

            return new SkeletCardController(HEALTH, _parentCardField, gameCardView);
        }
    }
}