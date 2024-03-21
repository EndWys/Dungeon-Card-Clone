using Assets.GameCore.GamePlay.Cards.BaseLogic;
using System;

namespace Assets.GameCore.GamePlay.Cards.ObjetsModification
{
    public class CoinObject : OnCardObjectBase, IDamageable, ICollectable
    {
        private int _coinsValue;

        public override event Action OnNeenToDestroy = () => { };
        protected override int ObjectValue => _coinsValue;
        public int Durability => _coinsValue;

        public override void Init(int starterValue)
        {
            //Iniate starter coin value;
        }

        public void Collect()
        {
            //When interacting with a coin, the player will move to its cell
            //Goblins can steal a coin
            //Different sources of fire can damage the coin
        }

        public void TakeDamage(int damage)
        {
            //Tacking dame reduce value of coin
        }

        public override void DestroyObject()
        {
            OnNeenToDestroy?.Invoke();
            //Add Coins to player Balance
            //Disable Card object
            //Maybe release to it pool
        }
    }
}