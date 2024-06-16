using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.PoolingSystem;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling
{
    public interface ICardsPoolContainer
    {
        public GameCardView CollectCard(Transform parent);

        public void ReleaseCard(GameCardView card);
    }

    public class DefaultCardsPoolContainer : ICardsPoolContainer
    {

        private Pooling<GameCardView> _pool = new Pooling<GameCardView>();

        public void Initialize(GameObject prefab)
        {
            _pool.CreateMoreIfNeeded = true;
            _pool.Initialize(prefab, null);
        }

        public GameCardView CollectCard(Transform parent)
        {
            return _pool.Collect(parent);
        }

        public void ReleaseCard(GameCardView card)
        {
            _pool.Release(card);
        }
    }
}