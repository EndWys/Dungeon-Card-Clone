using Assets.GameCore.GamePlay.InteractionStratagy;
using Assets.GameCore.PoolingSystem;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public interface IParentCard
    {
        OnCardUI OnCardUI { get; }

        Vector2Int Coord { get; }

        void OnKillCard();
    }

    public abstract class GameCardBase : PoolingObject, IPointerClickHandler, IParentCard
    {
        [SerializeField] protected OnCardUI _onCardUI;

        private IParentCardField _parentCardField;

        private Vector2Int _coordinates;

        private event Action _onKill;

        protected abstract OnCardObjectBase _onCardObject { get; }
        protected abstract BaseCardStratagy _stratagy { get; }

        public OnCardUI OnCardUI => _onCardUI;
        public Vector2Int Coord => _coordinates;

        #region Initialization
        public void Init(Vector2Int coord, IParentCardField parentField)
        {
            _coordinates = coord;
            _parentCardField = parentField;

            InitOnCardObject();
            InitOnCardUI();
        }

        protected virtual void InitOnCardObject()
        {
            _onCardObject.ParentCard = this;
        }
        #endregion

        protected abstract void InitOnCardUI();

        #region CardActions
        public void OnTap(IPlayerCardActions playerCard)
        {
            _stratagy.UseStratagy(playerCard);
        }

        public void Move(Vector2Int target)
        {
            _parentCardField.MoveCard(target, _coordinates);
            _coordinates = target;
        }
        #endregion

        #region OnPointerClick
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            _parentCardField.OnCardTap(_coordinates);
        }
        #endregion

        #region KillCard

        public void OnKillCard()
        {
            _onKill?.Invoke();
        }

        public void SetActionOnKill(Action action)
        {
            _onKill += action;
        }

        public override void OnCollect()
        {
            base.OnCollect();
            CachedTransform.localScale = Vector3.zero;
            CachedTransform.DOScale(Vector3.one, 0.4F);
        }

        public override void OnRelease()
        {
            base.OnRelease();
            _onKill -= OnKillCard;
        }
        #endregion
    }
}