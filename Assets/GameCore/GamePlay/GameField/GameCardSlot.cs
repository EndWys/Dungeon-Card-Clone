using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.Utilities.Objects;
using Cysharp.Threading.Tasks;

namespace Assets.GameCore.GamePlay
{
    public class GameCardSlot : CachedMonoBehaviour
    {
        private IOnFieldCard _card;
        public IOnFieldCard Card => _card;

        public async UniTask RemoveCard()
        {
            await _card.HideView();
            _card.Kill();
            _card = null;
        }

        public void SetCard(IOnFieldCard card)
        {
            _card = card;
        }

        public async UniTask MoveCard(GameCardSlot otherSlot)
        {
            await otherSlot.RemoveCard();
            await _card.MoveView(otherSlot.CachedTransform.position);

            otherSlot.SetCard(_card);
            _card.SetParent(otherSlot.CachedTransform);
            _card = null;


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