using Assets.GameCore.GamePlay.CardObjects.BaseLogic;
using System;

namespace Assets.GameCore.GamePlay
{
    public abstract class OnCardObjectBase : ITapable
    {
        public abstract event Action OnNeenToDestroy;
        protected abstract int ObjectValue { get; }
        public abstract void Init(int starterValue);
        public abstract void Tap(OneGameCard playerCard);
        public abstract void DestroyObject();
    }
}