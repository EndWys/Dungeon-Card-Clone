using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.MainHeroOptions;

namespace Assets.GameCore.GamePlay.Cards.PlayerCard
{
    public class PlayerCardController : GameCardController, IHealableCard
    {
        private int _health = 0;
        public int Health => _health;

        public PlayerCardController(IParentCardField parentCardField, GameCardView gameCardView) : base(parentCardField, gameCardView)
        {
            MainHeroHolder.Instance.Init(this);
        }

        public void TakeDamage(int damage)
        {
            //Take damage logic
        }

        public void Heal()
        {
            //Heal logic
        }

        public void StepDone()
        {
            _parentCardField.Step();
        }
    }
}