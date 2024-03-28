using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.CardsModification;
using Assets.GameCore.PoolingSystem;
using System.Linq;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling.PoolsContainer
{
    public class CoinsPoolContainer : CardsPoolContainerBase
    {
        private Pooling<CoinGameCard> _coinCardsPool;

        public override void Initialize()
        {
            _coinCardsPool = new Pooling<CoinGameCard>().Initialize(CardsDatabase.Instance.CoinCard, null);
        }
        public override GameCardBase CollectCard(Transform parent)
        {
            CoinGameCard card = _coinCardsPool.Collect(parent);

            card.SetActionOnKill(() => _coinCardsPool.Release(card));

            return card;
        }

    }
}