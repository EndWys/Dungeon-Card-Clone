using Assets.GameCore.GamePlay.Cards.BaseLogic;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.Potion
{
    public class PotionObject : OnCardObjectBase, IDamageable, ICollectable
    {
        private int _potionPower;

        protected override int ObjectValue => _potionPower;
        public int Durability => _potionPower;
        public override void Init(int starterValue)
        {
            _potionPower = starterValue;
        }

        public void Collect()
        {
            
        }

        public void TakeDamage(int damage)
        {

        }

        public override void Kill()
        {
            ParentCard.OnKillCard();
        }
    }
}