using Assets.GameCore.GamePlay.CardObjects.BaseLogic;
using Assets.GameCore.GamePlay.Cards;
using System;
using UnityEngine;

namespace Assets.GameCore.GamePlay
{
    public abstract class OnCardObjectBase : ITapable
    {
        //TODO: DELETE THIS!
        public Transform ParentCard;

        public abstract event Action OnNeenToDestroy;
        protected abstract int ObjectValue { get; }
        public abstract void Init(int starterValue);
        public abstract void Tap(IPlayerGameCard playerGameCard);
        public abstract void DestroyObject();
    }
}