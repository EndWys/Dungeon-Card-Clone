using Assets.GameCore.GamePlay.CardObjects.BaseLogic.MobsBaseLogic;
using Assets.GameCore.GamePlay.Cards;
using UnityEngine;

namespace Assets.GameCore.GamePlay.InteractionStratagy
{
    public class AttackMobStratage : BaseCardStratage<MobObjectBase>
    {
        public AttackMobStratage(MobObjectBase executor) : base(executor){ }

        public override void DoAction(IPlayerGameCard playerCard)
        {
            Debug.Log("AttackMob Stratage");
            //if player with weapon
            //Getting player weapon damage
            //Executor.TakeDamage(playerWeaponDamage)
            //else
            //playre take damage(executor.Health)
            //executor.Destroy()
        }
    }
}