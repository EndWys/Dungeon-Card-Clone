using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.InteractionStratagy;
using Assets.GameCore.GamePlay.Cards.ObjetsModification;
using Assets.GameCore.GamePlay.InteractionStratagy;

namespace Assets.GameCore.GamePlay.Cards.CardsModification
{
    public class CoinGameCard : OneGameCard
    {
        const int COIN_STARTER_VALUE = 1;

        private CoinObject _coinObject = new();
        public TakeCoinStratage _takeCoinStratage => new(_coinObject);

        protected override OnCardObjectBase _onCardObject => _coinObject;

        protected override BaseCardStratagy _stratagy => _takeCoinStratage;

        protected override void InitOnCardObject()
        {
            base.InitOnCardObject();
            _coinObject.Init(COIN_STARTER_VALUE);
        }
    }
}