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

    public abstract class DefaultCardsPoolContainer : CardsPoolContainerBase
    {
        protected abstract GameObject _prefab { get; }

        private Pooling<GameCardView> _pool = new Pooling<GameCardView>();

        public override void Initialize()
        {
            _pool.CreateMoreIfNeeded = true;
            _pool.Initialize(_prefab, null);
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