using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.MobsBaseLogic;
using Assets.GameCore.GamePlay.Cards.InteractionStratagy;
using Assets.GameCore.GamePlay.InteractionStratagy;

namespace Assets.GameCore.GamePlay.Cards.CardsModification
{
    public class MobGameCard : GameCardBase
    {
        const int MOB_STARTER_HEALTH = 4;

        private MobObjectBase _mobObject = new();
        private AttackMobStratage _attackMobStratage => new(_mobObject);
        protected override OnCardObjectBase _onCardObject => _mobObject;

        protected override BaseCardStratagy _stratagy => _attackMobStratage;

        protected override void InitOnCardObject()
        {
            base.InitOnCardObject();
            _mobObject.Init(MOB_STARTER_HEALTH);
        }

        protected override void InitOnCardUI()
        {
            _onCardUI.SetCardName("Enemy");
            _onCardUI.SetCardValue(MOB_STARTER_HEALTH.ToString());
        }
    }
}