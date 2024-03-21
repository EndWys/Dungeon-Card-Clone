using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.CardObjects.BaseLogic;
using Assets.GameCore.GamePlay.InteractionStratagy;
using System;

namespace Assets.GameCore.GamePlay.CardObjects.BaseLogic.MobsBaseLogic
{
    public /*abstract*/ class MobObjectBase : OnCardObjectBase, IDamageable, IStratageUser<AttackMobStratage>
    {
        private int _health;
        private int _coinsBenefit; //Value that player get when kill this mob = starter health value

        protected override int ObjectValue => _health;
        public int Durability => _health;

        public AttackMobStratage Strategy => new AttackMobStratage(this);

        public override event Action OnNeenToDestroy;

        public override void Init(int starterValue)
        {
            //Set starter _health value;
        }

        public override void Tap(OneGameCard oneGameCard)
        {
            Strategy.DoAction(oneGameCard);
        }

        public void UseStratage(OneGameCard player)
        {
            //Template method -> do something when tap on card: OnIneract; OnMoveTo; Destroy card;
        }

        public void TakeDamage(int damage)
        {
            //Reduce _health by damage
        }

        public override void DestroyObject()
        {
            //Destroy Mob, some actions
        }
    }
}