using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling.PoolsContainer;
using Assets.GameCore.GamePlay.Cards.ItemsCards.Potion;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling
{
    public class CardsPool
    {
        private List<CardsPoolContainerBase> _poolContainers;

        [Inject]
        public CardsPool()
        {
            _poolContainers = BuildPoolContainerList().ToList();
            Initialize();
        }

        private IEnumerable<CardsPoolContainerBase> BuildPoolContainerList()
        {
            yield return new CoinsPoolContainer();
            yield return new MobsPoolContainer();
            yield return new PotionPoolContainer();
        }

        private void Initialize()
        {
            foreach(var container in _poolContainers)
            {
                container.Initialize();
            }
        }

        public GameCardBase GetRandomCard(Transform parent)
        {
            return _poolContainers[Random.Range(0, _poolContainers.Count)].CollectCard(parent);
        }
    }
}