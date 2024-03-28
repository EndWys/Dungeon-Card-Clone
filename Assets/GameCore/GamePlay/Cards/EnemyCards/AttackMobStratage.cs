using Assets.GameCore.GamePlay.Cards.BaseLogic.MobsBaseLogic;
using Assets.GameCore.GamePlay.InteractionStratagy;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.InteractionStratagy
{
    public class AttackMobStratage : BaseCardStratagy
    {
        MobObjectBase _executor;
        public AttackMobStratage(MobObjectBase executor) => _executor = executor;

        public override void UseStratagy(IPlayerCardActions playerCard)
        {
            Debug.Log("AttackMob Stratage");
            //if player with weapon
            //Getting player weapon damage
            //Executor.TakeDamage(playerWeaponDamage)
            //else
            //playre take damage(executor.Health)
            playerCard.PlayerObject.TakeDamage(_executor.Durability);
            playerCard.Move(_executor.ParentCard.Coord);
            _executor.Kill();
        }
    }
}