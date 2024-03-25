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
    }

    public abstract class OneGameCard : PoolingObject, IPointerClickHandler, IParentCard
    {
        protected abstract OnCardObjectBase _onCardObject { get; }
        protected abstract BaseCardStratagy _stratagy { get; }

        private IParentCardField _parentCardField;
        private IParentCardSlot _parentSlot;

        private Vector2Int _coordinates;
        public Vector2Int Coord => _coordinates;

        private event Action Hide; 

        public void Init(Vector2Int coord, IParentCardSlot slot, IParentCardField parentField)
        {
            _coordinates = coord;
            _parentCardField = parentField;
            _parentSlot = slot;

            InitOnCardObject();
        }

        private void InitOnCardObject()
        {
            _onCardObject.ParentCard = this;
            _onCardObject.OnNeenToDestroy += Destor;
        }

        public void SetActionToDestroy(Action action)
        {
            Hide += action;
        }
        private void Destor()
        {
            Hide?.Invoke();
            Hide = null;
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

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            _parentCardField.OnCardClick(_coordinates);
        }
    }
}