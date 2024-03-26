using Assets.GameCore.GamePlay.InteractionStratagy;
using Assets.GameCore.PoolingSystem;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public interface IParentCard
    {
        Vector2Int Coord { get; }

        void OnKillCard();
    }

    public abstract class OneGameCard : PoolingObject, IPointerClickHandler, IParentCard
    {
        protected abstract OnCardObjectBase _onCardObject { get; }
        protected abstract BaseCardStratagy _stratagy { get; }

        private IParentCardField _parentCardField;

        private Vector2Int _coordinates;
        public Vector2Int Coord => _coordinates;

        private event Action OnKill; 

        public void Init(Vector2Int coord, IParentCardField parentField)
        {
            _coordinates = coord;
            _parentCardField = parentField;

            InitOnCardObject();
        }

        private void InitOnCardObject()
        {
            _onCardObject.ParentCard = this;
        }

        public void OnTap(IPlayerCardActions playerCard)
        {
            _stratagy.UseStratagy(playerCard);
        }

        public void Move(Vector2Int target)
        {
            _parentCardField.MoveCard(target, _coordinates);
            _coordinates = target;
        }

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
            OnKill?.Invoke();
        }

        public void SetActionOnKill(Action action)
        {
            OnKill += action;
        }


        private void OnDisable()
        {
            OnKill -= OnKillCard;
        }
        #endregion
    }
}