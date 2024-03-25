using Assets.GameCore.GamePlay.InteractionStratagy;
using Assets.GameCore.PoolingSystem;
using Assets.GameCore.Utilities.Objects;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public abstract class OneGameCard : PoolingObject, IPointerClickHandler
    {
        protected abstract OnCardObjectBase _onCardObject { get; }
        protected abstract BaseCardStratagy _stratagy { get; }

        private IParentCardField _cardClickReceiver;

        private Vector2Int _coordinates;
        public Vector2Int Coord => _coordinates;

        public void Init(Vector2Int coord, IParentCardField clickReceiver)
        {
            _coordinates = coord;
            _cardClickReceiver = clickReceiver;

            _onCardObject.OnNeenToDestroy += () => DestroyImmediate(CachedGameObject);
            //TODO: DELETE THIS!
            _onCardObject.ParentCard = this;
        }

        public void OnTap(IPlayerCardActions playerCard)
        {
            _stratagy.UseStratagy(playerCard);
        }

        public void Move(Vector2Int target)
        {
            _cardClickReceiver.MoveCard(target, _coordinates);
            _coordinates = target;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            _cardClickReceiver.OnCardClick(_coordinates);
        }
    }
}