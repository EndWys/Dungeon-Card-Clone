using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.PoolingSystem;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling
{
    public abstract class CardsPoolContainerBase
    {
        public abstract void Initialize();
        public abstract GameCardView CollectCard(Transform parent);
    }

    public class DefaultCardsPoolContainer : CardsPoolContainerBase
    {
        Pooling<GameCardView> _pool;

        public override void Initialize()
        {
            _pool.CreateMoreIfNeeded = true;
            _pool.Initialize(CardsDatabase.Instance.CoinCard, null);
        }

        public override GameCardView CollectCard(Transform parent)
        {
            return _pool.Collect(parent);
        }

        public void ReleaseCard(GameCardView card)
        {
            _pool.Release(card);
        }
    }
}