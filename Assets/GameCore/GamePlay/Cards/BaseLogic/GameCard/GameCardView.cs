using Assets.GameCore.PoolingSystem;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard
{
    public class GameCardView : PoolingObject, IPointerClickHandler
    {
        [SerializeField] private OnCardUI _cardUI;

        [SerializeField] private OnCardEquipeUI _equipeUI;

        public OnCardUI OnCardUI => _cardUI;

        //Кастыль, это поле не должно использоваться всеми контроллерами кард, оно должно быть только для Плейра
        public OnCardEquipeUI OnCardEquipeUI => _equipeUI;

        public event Action OnCardTap;
        public event Action OnKill;

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

        private async UniTask ShowView(float duration = 0.6F)
        {
            await CachedTransform.DOScale(Vector3.one, duration).AsyncWaitForCompletion().AsUniTask();
            await UniTask.Yield();
        }

        public override void OnRelease()
        {
            base.OnRelease();
            ShowView().Forget();

            OnCardTap = () => {};
            OnKill = () => { };
        }

        public void Kill()
        {
            OnKill?.Invoke();
        }
    }
}