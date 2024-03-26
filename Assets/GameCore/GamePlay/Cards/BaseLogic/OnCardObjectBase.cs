using System;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public abstract class OnCardObjectBase
    {
        public IParentCard ParentCard;
        protected abstract int ObjectValue { get; }
        public abstract void Init(int starterValue);
        public abstract void Kill();
    }
}