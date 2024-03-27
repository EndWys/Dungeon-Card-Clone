using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.Cards.CardsModification;
using Assets.GameCore.PoolingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.Potion
{
    public class PotionPoolContainer : CardsPoolContainerBase
    {
        private Pooling<PotionGameCard> _potionCardPool;

        public override void Initialize()
        {
            _potionCardPool = new Pooling<PotionGameCard>().Initialize(CardsDatabase.Instance.PotionnCard, null);
        }
        public override OneGameCard CollectCard(Transform parent)
        {
            PotionGameCard card = _potionCardPool.Collect(parent);

            card.SetActionOnKill(() => _potionCardPool.Release(card));

            return card;
        }
    }
}