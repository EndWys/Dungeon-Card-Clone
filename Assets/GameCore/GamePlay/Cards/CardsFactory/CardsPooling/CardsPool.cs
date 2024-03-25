using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling.PoolsContainer;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling
{
    public class CardsPool
    {
        private List<CardsPoolContainerBase> _poolContainers = new List<CardsPoolContainerBase>()
        {
            new CoinsPoolContainer(),
            new MobsPoolContainer(),
        };

        public void Initialize()
        {
            foreach(var container in _poolContainers)
            {
                container.Initialize();
            }
        }

        public OneGameCard GetRandomCard(Transform parent)
        {
            return _poolContainers[UnityEngine.Random.Range(0, _poolContainers.Count)].CollectCard(parent);
        }
    }
}