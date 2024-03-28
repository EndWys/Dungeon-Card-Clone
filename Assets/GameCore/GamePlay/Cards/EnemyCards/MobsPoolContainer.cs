using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.CardsModification;
using Assets.GameCore.PoolingSystem;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling.PoolsContainer
{
    public class MobsPoolContainer : CardsPoolContainerBase
    {
        private Pooling<MobGameCard> _mobCardsPool;

        public override void Initialize()
        {
            _mobCardsPool = new Pooling<MobGameCard>().Initialize(CardsDatabase.Instance.MobCard, null);
        }
        public override GameCardBase CollectCard(Transform parent)
        {
            MobGameCard card = _mobCardsPool.Collect(parent);

            card.SetActionOnKill(() => _mobCardsPool.Release(card));

            return card;
        }
    }
}