using Assets.GameCore.GamePlay.InteractionStratagy;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public abstract class OneGameCard : MonoBehaviour, IPointerClickHandler
    {
        protected abstract OnCardObjectBase _onCardObject { get; }
        protected abstract BaseCardStratagy _stratagy { get; }

        private ICardClickReceiver _cardClickReceiver;

        private Vector2Int _coordinates;

        public void Init(Vector2Int coord, ICardClickReceiver clickReceiver)
        {
            _coordinates = coord;
            _cardClickReceiver = clickReceiver;

            _onCardObject.OnNeenToDestroy += () => DestroyImmediate(gameObject);
            _onCardObject.ParentCard = transform;
        }

        public void OnTap(IPlayerCardActions playerCard)
        {
            _stratagy.UseStratagy(playerCard);
        }

        public void Move(Vector3 pos)
        {
            transform.DOMove(pos, 0.3F);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            _cardClickReceiver.OnCardClick(_coordinates);
        }
    }
}