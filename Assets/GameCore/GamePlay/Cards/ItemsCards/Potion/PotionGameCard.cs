using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.InteractionStratagy;
using Assets.GameCore.GamePlay.Cards.ObjetsModification;
using Assets.GameCore.GamePlay.InteractionStratagy;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.Potion
{
    public class PotionGameCard : OneGameCard
    {
        const int POTION_STARTER_VALUE = 2;

        private PotionObject _potionObject = new();
        public TakePotionStratagy _takePotionStratagy => new(_potionObject);

        protected override OnCardObjectBase _onCardObject => _potionObject;

        protected override BaseCardStratagy _stratagy => _takePotionStratagy;

        protected override void InitOnCardObject()
        {
            base.InitOnCardObject();
            _potionObject.Init(POTION_STARTER_VALUE);
        }
    }
}