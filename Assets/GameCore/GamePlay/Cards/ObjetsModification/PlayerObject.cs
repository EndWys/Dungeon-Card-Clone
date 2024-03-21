using Assets.GameCore.GamePlay.Cards.BaseLogic;
using System;

namespace Assets.GameCore.GamePlay.CardObjects.ObjetsModification
{
    public class PlayerObject : OnCardObjectBase, IDamageable
    {
        private int _health;

        protected override int ObjectValue => _health;

        public int Durability => _health;

        public override event Action OnNeenToDestroy = () => { };
        //Carriying weapon mechanic
        public override void Init(int starterValue)
        {
            //Set starter _health value;
        }

        public void TakeDamage(int damage)
        {
            //Reduce _health by damage
            //If health <= 0 -> Game Over
        }


        public override void DestroyObject()
        {
            //Destroy Player, some actions
        }
    }
}