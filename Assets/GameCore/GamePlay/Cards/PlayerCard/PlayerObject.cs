using Assets.GameCore.GamePlay.Cards.BaseLogic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.CardObjects.ObjetsModification
{
    public class PlayerObject : OnCardObjectBase, IDamageable
    {
        private int _health;

        protected override int ObjectValue => _health;
        public int Durability => _health;

        //Carriying weapon mechanic
        public override void Init(int starterValue)
        {
            _health = starterValue;
        }

        public void TakeDamage(int damage)
        {
            if(_health < damage)
            {
                _health = 0;
            }
            else
            {
                _health -= damage;
            }

            if(_health <= 0)
            {
                Debug.Log("health <= 0 -> Game Over");
            }
        }


        public override void Kill()
        {
            ParentCard.OnKillCard();
        }
    }
}