using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.GameCore.GamePlay
{
    public class OneGameCard : MonoBehaviour, IPointerClickHandler
    {
        private OnCardObjectBase _onCardObject;

        private ICardClickReceiver _cardClickReceiver;

        private Vector2Int _coordinates;

        public void Init(Vector2Int coord, ICardClickReceiver clickReceiver) 
        {
            _coordinates = coord;
            _cardClickReceiver = clickReceiver;
        }

        public void SetOnCardObject(OnCardObjectBase onCardObjectBase)
        {
            _onCardObject = onCardObjectBase;
            _onCardObject.OnNeenToDestroy += () => DestroyImmediate(gameObject);
        }

        public void OnTap(OneGameCard playerCard)
        {
            _onCardObject.Tap(playerCard);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("OnPointerClick");

            if(eventData.button != PointerEventData.InputButton.Left)
                return;

            _cardClickReceiver.OnCardClick(_coordinates);
        }
    }
}