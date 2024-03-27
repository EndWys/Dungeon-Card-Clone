using Assets.GameCore.GamePlay.Cards.BaseLogic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling
{
    public abstract class CardsPoolContainerBase
    {
        public abstract void Initialize();
        public abstract OneGameCard CollectCard(Transform parent);
    }
}