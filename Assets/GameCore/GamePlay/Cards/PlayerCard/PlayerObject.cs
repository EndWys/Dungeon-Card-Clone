using Assets.GameCore.GamePlay.Cards.BaseLogic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.CardObjects.ObjetsModification
{
    public class PlayerObject : OnCardObjectBase, IDamageableAndHealable
    {
        private int _maxHealth;

        private int _health;

        protected override int ObjectValue => _health;
        public int Durability => _health;

        //Carriying weapon mechanic
        public bool IsDead => _health <= 0;

        public override void Init(int starterValue)
        {
            _health = starterValue;
            _maxHealth = starterValue;
        }

        public void TakeDamage(int damage)
        {
            if (_health < damage)
            {
                _health = 0;
            }
            else
            {
                _health -= damage;
            }

            if (_health <= 0)
            {
                Debug.Log("health <= 0 -> Game Over");
            }

            ParentCard.OnCardUI.SetCardValue($"{_health}/{_maxHealth}");
        }

        public void Heal(int heal)
        {
            int newHealth = _health + heal;

            if (newHealth < _health)
            {
                Debug.LogError("Heal value is negative");
                return;
            }

            if (newHealth > _maxHealth)
            {
                _health = _maxHealth;
            }
            else
            {
                _health = newHealth;
            }

            ParentCard.OnCardUI.SetCardValue($"{_health}/{_maxHealth}");
        }


        public override void Kill()
        {
            ParentCard.OnKillCard();
        }
    }
}