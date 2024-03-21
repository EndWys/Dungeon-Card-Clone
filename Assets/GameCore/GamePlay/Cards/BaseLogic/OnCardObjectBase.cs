using System;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public abstract class OnCardObjectBase
    {
        //TODO: DELETE THIS!
        public Transform ParentCard;

        public abstract event Action OnNeenToDestroy;
        protected abstract int ObjectValue { get; }
        public abstract void Init(int starterValue);
        public abstract void DestroyObject();
    }
}