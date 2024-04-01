using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.Utilities.Objects;
using UnityEngine;

namespace Assets.GameCore.GamePlay
{
    public class GameCardSlot : CachedMonoBehaviour
    {
        private GameCardController _card;
        public GameCardController Card => _card;

        private void RemoveCard()
        {
            _card = null;
        }

        public void SetCard(GameCardController card)
        {
            _card = card;
        }

        public async void MoveCard(GameCardSlot otherSlot)
        {
            otherSlot.SetCard(_card);
            await _card.MoveView(otherSlot.CachedTransform.position);
            _card.SetParent(otherSlot.CachedTransform);
            otherSlot.SetCard(_card);
            RemoveCard();
            
        }

        public async void SwapCards(GameCardSlot otherSlot)
        {
            var otherCard = otherSlot.Card;

            await _card.MoveView(otherSlot.CachedTransform.position);
            _card.SetParent(otherSlot.CachedTransform);
            otherSlot.SetCard(_card);

            await otherCard.MoveView(CachedTransform.position);
            otherCard.SetParent(CachedTransform);
            SetCard(otherCard);
        }
    }
}