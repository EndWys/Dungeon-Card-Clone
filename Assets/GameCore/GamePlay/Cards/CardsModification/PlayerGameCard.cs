using Assets.GameCore.GamePlay.CardObjects.ObjetsModification;
using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.MobsBaseLogic;
using Assets.GameCore.GamePlay.Cards.InteractionStratagy;
using Assets.GameCore.GamePlay.InteractionStratagy;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.CardsModification
{
    public class PlayerGameCard : OneGameCard, IPlayerCardActions
    {
        private PlayerObject _playerObject = new();
        private AttackMobStratage _playerStratage => new(new MobObjectBase());

        protected override OnCardObjectBase _onCardObject => _playerObject;

        protected override BaseCardStratagy _stratagy => _playerStratage;

        public new void Move(Vector2Int pos)
        {
            base.Move(pos);
        }
    }
}