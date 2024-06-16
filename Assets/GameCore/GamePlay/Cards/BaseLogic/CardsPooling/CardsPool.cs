using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.EnemyCards.Skelet;
using Assets.GameCore.GamePlay.Cards.EnemyCards.Zombie;
using Assets.GameCore.GamePlay.Cards.ItemsCards.Coin;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling
{
    public class CardsPool
    {
        private Dictionary<Type, DefaultCardsPoolContainer> _poolContainers;

        [Inject]
        public CardsPool()
        {
            _poolContainers = BuildPoolContainerList();
            Initialize();
        }

        private Dictionary<Type, DefaultCardsPoolContainer> BuildPoolContainerList()
        {
            return new()
            {
                { typeof(CoinCardController), new CoinCardPoolContainer() },
                { typeof(SkeletCardController), new SkeletCardPoolContainer() },
                { typeof(ZombieCardController), new ZombieCardPoolContainer() },
                { typeof(PlayerCardController), new PlayerCardPoolContainer() },
            };
        }

        private void Initialize()
        {
            foreach (var container in _poolContainers)
            {
                container.Value.Initialize();
            }
        }

        public GameCardView CollectCard(Type type, Transform parent)
        {
            return _poolContainers[type].CollectCard(parent);
        }

        public void Release(Type type, GameCardView card)
        {
            _poolContainers[type].ReleaseCard(card);
        }
    }
}