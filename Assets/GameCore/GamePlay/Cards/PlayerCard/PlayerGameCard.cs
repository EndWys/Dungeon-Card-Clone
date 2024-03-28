using Assets.GameCore.GamePlay.CardObjects.ObjetsModification;
using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.MobsBaseLogic;
using Assets.GameCore.GamePlay.Cards.InteractionStratagy;
using Assets.GameCore.GamePlay.InteractionStratagy;
using Assets.GameCore.Utilities;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.CardsModification
{
    public class PlayerGameCard : GameCardBase, IPlayerCardActions
    {
        const int PLAYER_STARTER_HEALTH = 15;

        private PlayerObject _playerObject = new();
        private AttackMobStratage _playerStratage => new(new MobObjectBase());

        protected override OnCardObjectBase _onCardObject => _playerObject;

        protected override BaseCardStratagy _stratagy => _playerStratage;

        public PlayerObject PlayerObject => _playerObject;

        protected override void InitOnCardObject()
        {
            base.InitOnCardObject();
            _playerObject.Init(PLAYER_STARTER_HEALTH);
        }

        public bool ValidateAction(Vector2Int target)
        {
            if (_playerObject.IsDead)
            {
                Debug.Log("Player is dead");
                return false;
            }

            return GamePlayeUtil.GetNeigneighbourSlots(Coord).Contains(target);
        }

        protected override void InitOnCardUI()
        {
            _onCardUI.SetCardName("Hero");
            _onCardUI.SetCardValue(PLAYER_STARTER_HEALTH.ToString());
        }
    }
}