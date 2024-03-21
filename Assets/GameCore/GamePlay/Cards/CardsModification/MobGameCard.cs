using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.MobsBaseLogic;
using Assets.GameCore.GamePlay.Cards.InteractionStratagy;
using Assets.GameCore.GamePlay.InteractionStratagy;

namespace Assets.GameCore.GamePlay.Cards.CardsModification
{
    public class MobGameCard : OneGameCard
    {
        private MobObjectBase _mobObject = new();
        private AttackMobStratage _attackMobStratage => new(_mobObject);
        protected override OnCardObjectBase _onCardObject => _mobObject;

        protected override BaseCardStratagy _stratagy => _attackMobStratage;
    }
}