using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.ItemsCards.Coin;
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

                { typeof(CoinCardController), new DefaultCardsPoolContainer() }

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
    }
}