using Assets.GameCore.PoolingSystem;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard
{
    public class GameCardView : PoolingObject, IPointerClickHandler
    {
        public event Action OnCardTap;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnCardTap?.Invoke();
        }

        public void SetParent(Transform parent)
        {
            CachedTransform.SetParent(parent);
        }

        public async UniTask MoveView(Vector3 pos, float duration = 0.3F)
        {
            await CachedTransform.DOMove(pos, duration).AsyncWaitForCompletion().AsUniTask();
            await UniTask.Yield();
        }

        public async UniTask HideView(float duration = 0.3F)
        {
            await CachedTransform.DOScale(Vector3.zero, duration).AsyncWaitForCompletion().AsUniTask();
            await UniTask.Yield();
        }
    }
}