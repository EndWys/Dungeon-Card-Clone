using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.InteractionStratagy;
using Assets.GameCore.GamePlay.Cards.ObjetsModification;
using Assets.GameCore.GamePlay.InteractionStratagy;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.Potion
{
    public class PotionGameCard : GameCardBase
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

        protected override void InitOnCardUI()
        {
            _onCardUI.SetCardName("Potion");
            _onCardUI.SetCardValue(POTION_STARTER_VALUE.ToString());
        }
    }
}