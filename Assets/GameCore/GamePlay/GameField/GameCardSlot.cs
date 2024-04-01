using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.Utilities.Objects;
using Cysharp.Threading.Tasks;

namespace Assets.GameCore.GamePlay
{
    public class GameCardSlot : CachedMonoBehaviour
    {
        private GameCardController _card;
        public GameCardController Card => _card;

        private async UniTask RemoveCard()
        {
            await _card.HideView();
            _card.Kill();
            _card = null;
        }

        public void SetCard(GameCardController card)
        {
            _card = card;
        }

        public async UniTask MoveCard(GameCardSlot otherSlot)
        {
            otherSlot.SetCard(_card);
            await _card.MoveView(otherSlot.CachedTransform.position);
            _card.SetParent(otherSlot.CachedTransform);
            otherSlot.SetCard(_card);
            await RemoveCard();
            
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