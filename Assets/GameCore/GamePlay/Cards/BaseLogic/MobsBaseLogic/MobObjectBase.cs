using System;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.MobsBaseLogic
{
    public /*abstract*/ class MobObjectBase : OnCardObjectBase, IDamageable
    {
        private int _health;
        private int _coinsBenefit; //Value that player get when kill this mob = starter health value

        protected override int ObjectValue => _health;
        public int Durability => _health;

        public override event Action OnNeenToDestroy = () => { };

        public override void Init(int starterValue)
        {
            //Set starter _health value;
        }

        public void TakeDamage(int damage)
        {
            //Reduce _health by damage
        }

        public override void DestroyObject()
        {
            OnNeenToDestroy?.Invoke();
        }
    }
}