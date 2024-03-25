using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.CardsModification;
using Assets.GameCore.PoolingSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling
{
    public class CardsPool
    {
        //TODO: Use ths insted of _cardGetters...
        private List<CardsPoolContainer> _poolContainers = new List<CardsPoolContainer>();

        private List<Func<Transform,OneGameCard>> _cardGetters = new()
        {
            GetMobCard,
            GetCoinCard,
        };

        private static Pooling<MobGameCard> _mobGameCards;
        private static Pooling<CoinGameCard> _coinCardPool;

        public void Initialize()
        {
            _mobGameCards = new Pooling<MobGameCard>().Initialize(CardsDatabase.Instance.MobCard, null);
            _coinCardPool = new Pooling<CoinGameCard>().Initialize(CardsDatabase.Instance.CoinCard, null);
        }

        public OneGameCard GetRandomCard(Transform parent)
        {
            return _cardGetters[UnityEngine.Random.Range(0, _cardGetters.Count)](parent);
        }

        public static OneGameCard GetMobCard(Transform parent)
        {
            return _mobGameCards.Collect(parent);
        }

        public static OneGameCard GetCoinCard(Transform parent)
        {
            return _coinCardPool.Collect(parent);
        }
    }

    public abstract class CardsPoolContainer
    {
        public abstract OneGameCard GetCard(Transform parent);
        public abstract OneGameCard HideCard();
    }
}